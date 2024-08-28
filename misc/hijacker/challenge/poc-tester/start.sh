#!/bin/bash

function kill_emulator() {
  adb devices | grep emulator | cut -f1 | xargs -I {} adb -s "{}" emu kill
};

function start_emulator() {
  echo "Starting emulator..."

  accel_option=""

  if [[ "$OSTYPE" == "linux-gnu"* ]]; then
    if [[ $(egrep -c '(vmx|svm)' /proc/cpuinfo) -gt 0 ]]; then
      accel_option="-accel on"
    else
      accel_option="-no-accel"
    fi
  elif [[ "$OSTYPE" == "darwin"* ]]; then
    accel_option="-accel on"
  elif [[ "$OSTYPE" == "msys" ]]; then
    accel_option="-accel hax"
  else
    accel_option="-no-accel"
  fi

  nohup emulator -avd "$EMULATOR_NAME" -writable-system -no-window -noaudio -no-boot-anim -memory 2048 $accel_option &
};

function wait_for_device() {
  echo "Waiting for device..."
  adb wait-for-device

  while [ "$(adb get-state)" == "offline" ]; do
      sleep 1
  done
};

function setup_device() {
  echo "Setting up device..."

  adb root
  sleep 5

  adb shell avbctl disable-verification
  adb disable-verity
  adb reboot
};

function init_device() {
  echo "Initializing device..."

  adb root
  sleep 5

  adb remount
  sleep 5

  adb push lamda-server-x86_64.tar.gz /data
  adb shell tar -zxf /data/lamda-server-x86_64.tar.gz -C /data
  adb shell chmod +x /data/server/bin/launch.sh
  adb shell /data/server/bin/launch.sh
  adb forward tcp:65000 tcp:65000

  adb shell mv /system/xbin/su /system/xbin/su.bak
};

adb start-server

kill_emulator
start_emulator
wait_for_device
setup_device

while true; do
    result=$(adb shell getprop sys.boot_completed 2>&1)

    if [ "$result" == "1" ]; then
        break
    fi

    sleep 1
done;

wait_for_device
init_device

python3 -u app.py