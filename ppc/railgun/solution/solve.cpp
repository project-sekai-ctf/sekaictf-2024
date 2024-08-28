#include <iostream>
#include <vector>
#include <set>
using namespace std;
 
const int MAX_N = 2001;
 
bool reflect[MAX_N][MAX_N];
vector<int> cycles(MAX_N);
 
bool help(vector<int>& arr, int x, int y) {
  return cycles[x] == cycles[y];
}
 
void upd(vector<int>& arr, int a, int b) {
  int x, y;
  for (int i = 0; i < (int) arr.size(); ++i) {
    if (arr[i] == a) x = i;
    if (arr[i] == b) y = i;
  }
  swap(arr[x], arr[y]);
  for (int i = 0; i < (int) arr.size(); ++i) cycles[i] = 0;
  int cyc = 1;
  for (int i = 0; i < (int) arr.size(); ++i) {
    if (cycles[i] > 0) continue;
    cycles[i] = cyc;
    int tmp = i;
    while ((tmp = arr[tmp]) != i) {
      cycles[tmp] = cyc;
    }
    cyc++;
  }
}
 
void solve() {
  int n; cin >> n;
  for (int i = 0; i <= n; ++i) {
    cycles[i] = 0;
    for (int j = 0; j <= n; ++j) reflect[i][j] = 0;
  }
  vector<int> a(n), b(n);
  for (int i = 0; i < n; ++i) cin >> a[i];
  for (int i = 0; i < n; ++i) cin >> b[i];
  vector<int> mp(n);
  for (int i = 0; i < n; ++i) mp[b[i] - 1] = i;
  for (int i = 0; i < n; ++i) a[i] = mp[a[i] - 1], b[i] = i;
  vector<int> arr = a;
  vector<int> pos(n);
  for (int i = 0; i < n; ++i) pos[arr[i]] = i;
  int type = n & 1;
  for (int i = 0; i < n; ++i) reflect[0][i] = reflect[n][i] = true;
  vector<set<int>> ss(2);
  for (int i = 0; i < n; ++i) ss[i & 1].insert(arr[i]);
  vector<int> rend(n);
  for (int i = n - 1; i >= 0; --i) {
    int end = n - 1 - i;
    int idx = i & 1;
    if (ss[idx].count(end)) {
      ss[idx].erase(end);
      rend[end] = arr[i];
      continue;
    }
    for (int num : ss[idx]) {
      if ((idx == (num & 1) && (n & 1)) || (idx != (num & 1) && !(n & 1))) {
        int l = 0, r = n;
        int h1 = i, h2 = num + 1;
        if (h1 < h2) {
          r -= h2 - h1;
          h2 = h1;
        } else {
          l += h1 - h2;
          h1 = h2;
        }
        int md = (l + r) / 2;
        int h = h1 - (md - l);
        reflect[h][md] = true;
        ss[idx].erase(num);
        rend[num] = arr[i];
        break;
      } else {
        int l = 0, r = n;
        int h1 = i, h2 = num;
        if (h1 < h2) {
          l += h2 - h1;
          h1 = h2;
        } else {
          r -= h1 - h2;
          h2 = h1;
        }
        int md = (l + r) / 2;
        int h = h1 + (md - l);
        if (h > n) continue;
        reflect[i][0] = true;
        reflect[h][md] = true;
        ss[idx].erase(num);
        rend[num] = arr[i];
        break;
      }
    }
  }
  vector<vector<vector<int>>> ints(n + 1, vector<vector<int>>(n));
  for (int i = 0; i < n; ++i) {
    int r = i, c = 0;
    bool up = true;
    while (c < n) {
      if (reflect[r][c]) up = !up;
      else ints[r][c].push_back(arr[i]);
      r += (up ? -1 : 1);
      ++c;
    }
  }
  vector<int> norm(n); for (int i = 0; i < n; ++i) norm[i] = i;
  upd(rend, 0, 0);
  for (int c = n - 1; c >= 0; --c) {
    for (int r = 1; r < n; ++r) {
      if (ints[r][c].size() == 2) {
        int a2 = ints[r][c][0], b2 = ints[r][c][1];
        if (help(rend, a2, b2)) {
          reflect[r][c] = !reflect[r][c];
          upd(rend, a2, b2);
        }
      }
    }
  }
  for (int i = 1; i < n; ++i) {
    for (int j = 0; j < n; ++j) cout << reflect[i][j];
    cout << '\n';
  }
  // uncomment out for built-in checker
  // for (int i = 0; i < n; ++i) {
  //   int r = i, c = 0;
  //   bool up = true;
  //   while (c < n) {
  //     if (reflect[r][c]) up = !up;
  //     r += (up ? -1 : 1);
  //     ++c;
  //   }
  //   if (!up) --r;
  //   assert(a[i] == b[r]);
  // }
}
 
int main() {
  int t; cin >> t;
  for (int i = 0; i < t; ++i) solve();
  return 0;
}