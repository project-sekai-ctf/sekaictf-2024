#!/bin/sh
/app/pow || (echo "incorrect pow" && exit)
cd /app && sage challenge.sage