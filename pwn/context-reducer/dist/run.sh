#!/bin/bash

JSFILE="$(mktemp -p /tmp --suffix=.js)"
function cleanup {
    rm -f "$JSFILE"
}
trap cleanup EXIT
timeout 60 python3 -u /server.py $JSFILE
