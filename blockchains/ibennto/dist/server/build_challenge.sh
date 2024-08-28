#!/bin/bash

cd chall && solang compile
cd ..
cargo build --release