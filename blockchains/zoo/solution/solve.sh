export RPC=<rpc>
export PVKEY=<pvKey>
export SETUP=<setup-address>

forge init --force .
forge script --broadcast --rpc-url $RPC --private-key $PVKEY ./Solve.s.sol:Solve --evm-version cancun
