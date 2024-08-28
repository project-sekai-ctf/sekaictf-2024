#include <bits/stdc++.h>
using namespace std;

#define rep(i, a, b) for(int i = a; i < (b); ++i)
#define all(x) begin(x), end(x)
#define sz(x) (int)(x).size()
typedef long long ll;
typedef pair<int, int> pii;
typedef vector<int> vi;

typedef complex<double> C;
typedef vector<double> vd;
void fft(vector<C>& a) {
	int n = sz(a), L = 31 - __builtin_clz(n);
	static vector<complex<long double>> R(2, 1);
	static vector<C> rt(2, 1);  // (^ 10% faster if double)
	for (static int k = 2; k < n; k *= 2) {
		R.resize(n); rt.resize(n);
		auto x = polar(1.0L, acos(-1.0L) / k);
		rep(i,k,2*k) rt[i] = R[i] = i&1 ? R[i/2] * x : R[i/2];
	}
	vi rev(n);
	rep(i,0,n) rev[i] = (rev[i / 2] | (i & 1) << L) / 2;
	rep(i,0,n) if (i < rev[i]) swap(a[i], a[rev[i]]);
	for (int k = 1; k < n; k *= 2)
		for (int i = 0; i < n; i += 2 * k) rep(j,0,k) {
			// C z = rt[j+k] * a[i+j+k]; // (25% faster if hand-rolled)  /// include-line
			auto x = (double *)&rt[j+k], y = (double *)&a[i+j+k];        /// exclude-line
			C z(x[0]*y[0] - x[1]*y[1], x[0]*y[1] + x[1]*y[0]);           /// exclude-line
			a[i + j + k] = a[i + j] - z;
			a[i + j] += z;
		}
}
vd conv(const vd& a, const vd& b) {
	if (a.empty() || b.empty()) return {};
	vd res(sz(a) + sz(b) - 1);
	int L = 32 - __builtin_clz(sz(res)), n = 1 << L;
	vector<C> in(n), out(n);
	copy(all(a), begin(in));
	rep(i,0,sz(b)) in[i].imag(b[i]);
	fft(in);
	for (C& x : in) x *= x;
	rep(i,0,n) out[i] = in[-i & (n - 1)] - conj(in[i]);
	fft(out);
	rep(i,0,sz(res)) res[i] = imag(out[i]) / (4 * n);
	return res;
}
vector<int> multiply(vector<int> a, vector<int> b) {
  vd aa(a.size()), bb(b.size());
  for (int i = 0; i < (int) a.size(); ++i) aa[i] = (double) a[i];
  for (int i = 0; i < (int) b.size(); ++i) bb[i] = (double) b[i];
  vd res = conv(aa, bb);
  vector<int> resres(res.size());
  for (int i = 0; i < (int) res.size(); ++i) resres[i] = (int) (res[i] + 0.5);
  return resres;
}

void solve() {
  int n; cin >> n;
  vector<vector<int>> dpFull0(24);
  vector<vector<int>> dpFull1(24);
  vector<vector<int>> dpPartial0(24);
  vector<vector<int>> dpPartial1(24);
  dpFull0[0] = {1};
  dpFull1[0] = {0, 1};
  vector<pair<bool, int>> info(n + 1); // true = full, false = not full
  for (int i = n; i > 0; --i) {
    if (2 * i > n) info[i] = {true, 0};
    else if (2 * i + 1 > n) info[i] = {false, 1};
    else if (!info[2 * i].first || !info[2 * i + 1].first) info[i] = {false, info[2 * i].second + 1};
    else if (info[2 * i].second != info[2 * i + 1].second) info[i] = {false, info[2 * i].second + 1};
    else info[i] = {true, info[2 * i].second + 1};
  }
  for (int i = n; i > 0; --i) {
    int lvl = info[i].second;
    if (info[i].first) {
      if ((int) dpFull0[lvl].size()) continue;
      // needs to calculate dp:
      vector<int> t1 = multiply(dpFull0[lvl - 1], dpFull0[lvl - 1]);
      vector<int> t2 = multiply(dpFull0[lvl - 1], dpFull1[lvl - 1]); // shift, assign dpFull1
      vector<int> t3 = multiply(dpFull1[lvl - 1], dpFull0[lvl - 1]); // shift, assign dpFull1
      vector<int> t4 = multiply(dpFull1[lvl - 1], dpFull1[lvl - 1]);
      dpFull0[lvl].resize(max(t1.size(), t4.size()));
      for (int i = 0; i < dpFull0[lvl].size(); ++i) if ((i < (int) t1.size() && t1[i]) || (i < (int) t4.size() && t4[i])) dpFull0[lvl][i] = 1;
      dpFull1[lvl].resize(max(t2.size(), t3.size()) + 1);
      for (int i = 1; i < dpFull1[lvl].size(); ++i) if ((i - 1 < (int) t2.size() && t2[i - 1]) || (i - 1 < (int) t3.size() && t3[i - 1])) dpFull1[lvl][i] = 1;
    } else {
      // only one node per level, need to calculate dp no matter what:
      if (2 * i + 1 > n) {
        dpPartial0[lvl] = {1};
        dpPartial1[lvl] = {0, 0, 1};
      } else {
        vector<int> t1;
        vector<int> t2;
        vector<int> t3;
        vector<int> t4;
        if (!info[2 * i].first) {
          t1 = multiply(dpPartial0[lvl - 1], dpFull0[lvl - 2]);
          t2 = multiply(dpPartial0[lvl - 1], dpFull1[lvl - 2]);
          t3 = multiply(dpPartial1[lvl - 1], dpFull0[lvl - 2]);
          t4 = multiply(dpPartial1[lvl - 1], dpFull1[lvl - 2]);
        } else if (!info[2 * i + 1].first) {
          t1 = multiply(dpFull0[lvl - 1], dpPartial0[lvl - 1]);
          t2 = multiply(dpFull0[lvl - 1], dpPartial1[lvl - 1]);
          t3 = multiply(dpFull1[lvl - 1], dpPartial0[lvl - 1]);
          t4 = multiply(dpFull1[lvl - 1], dpPartial1[lvl - 1]);
        } else {
          t1 = multiply(dpFull0[lvl - 1], dpFull0[lvl - 2]);
          t2 = multiply(dpFull0[lvl - 1], dpFull1[lvl - 2]);
          t3 = multiply(dpFull1[lvl - 1], dpFull0[lvl - 2]);
          t4 = multiply(dpFull1[lvl - 1], dpFull1[lvl - 2]);
        }
        dpPartial0[lvl].resize(max(t1.size(), t4.size()));
        for (int i = 0; i < dpPartial0[lvl].size(); ++i) if ((i < (int) t1.size() && t1[i]) || (i < (int) t4.size() && t4[i])) dpPartial0[lvl][i] = 1;
        dpPartial1[lvl].resize(max(t2.size(), t3.size()) + 1);
        for (int i = 1; i < dpPartial1[lvl].size(); ++i) if ((i - 1 < (int) t2.size() && t2[i - 1]) || (i - 1 < (int) t3.size() && t3[i - 1])) dpPartial1[lvl][i] = 1;
      }
    }
  }
  int lvl = info[1].second;
  set<int> ans;
  if (info[1].first) {
    for (int i = 0; i < (int) dpFull0[lvl].size(); ++i) if (dpFull0[lvl][i]) ans.insert(i);
    for (int i = 0; i < (int) dpFull1[lvl].size(); ++i) if (dpFull1[lvl][i]) ans.insert(i);
  } else {
    for (int i = 0; i < (int) dpPartial0[lvl].size(); ++i) if (dpPartial0[lvl][i]) ans.insert(i);
    for (int i = 0; i < (int) dpPartial1[lvl].size(); ++i) if (dpPartial1[lvl][i]) ans.insert(i);
  }
  cout << ans.size() << '\n';
}

int main() {
  ios_base::sync_with_stdio(false); cin.tie(NULL);
  int t; cin >> t;
  for (int i = 0; i < t; ++i) solve();
  return 0;
}
