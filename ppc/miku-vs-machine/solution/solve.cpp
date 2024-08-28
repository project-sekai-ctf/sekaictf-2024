#include <iostream>
using namespace std;

#define ll long long

void solve() {
  int n, m; cin >> n >> m;
  cout << n << '\n';
  ll end = 0;
  int at = 1;
  for (ll i = 0; i < m; ++i) {
    ll l = i * n, r = (i + 1) * n;
    if (end + m < r) {
      cout << (end + m - l) << ' ' << at << ' ' << (r - end - m) << ' ' << (at + 1) << '\n';
      end += m, at += 1;
    } else {
      cout << (r - l) << ' ' << at << ' ' << 0 << ' ' << at << '\n';
    }
  }
}

int main() {
  int t; cin >> t;
  for (int i = 0; i < t; ++i) solve();
  return 0;
}
