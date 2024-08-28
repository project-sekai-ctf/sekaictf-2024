## Writeup

### Background

This is a Mobile reverse engineering challenge. Instead of Java, I picked React Native as I worked with it a few years ago, and it seems less common than Java/Kotlin in CTF scenes.

The overall goal is to reverse the Android application and try to login as admin user. The challenge involves little bit of knowledge about cloud (Firebase DB) and crypto (simple AES encryption).

### APK Overview

To begin with, we can download the APK and play around with it. Opening the app (either on real device or on Android emulator), we are greeted with a welcome screen. Clicking "CRACKME" will bring us to the login page, where email and password are required for login. There is also a checkbox on becoming the admin but this is just a troll and useless for the challenge.

Playing around with random emails and passwords, we can see that there is a simple email format check and password empty check. If they are valid, the app will try to login using Firebase authentication. In our case, since we don't have an account, the login will fail.

The error message is clear:

```
Firebase: Error (auth/user-not-found).
```

Now we need to reverse the APK to find out what are the credentials for admin login.

### Decompile

The first step is to decompile the APK. Since it is a React Native app using JavaScript, we cannot use Jadx. A quick search on Google shows we can use tools such as [react-native-decompiler](https://github.com/richardfuca/react-native-decompiler) to decompile React Native `index.android.bundle` JS files. Renaming `CrackMe.apk` to `CrackMe.zip` and extracting it, we can see that the `index.android.bundle` is located at `assets/index.android.bundle`. Then we use the tool to decompile it.

```bash
% npm start -- -i ./index.android.bundle -o ./output
> react-native-decompiler@0.1.0 start
> npm i && ts-node ./src/main.ts "-i" "./index.android.bundle" "-o" "./output"
> react-native-decompiler@0.1.0 postinstall
> patch-package

patch-package 6.4.7
Applying patches...
@babel/types@7.12.11 ✔
@types/babel__traverse@7.11.0 ✔
@types/command-line-args@5.0.0 ✔
@types/fs-extra@9.0.6 ✔

added 785 packages in 57s
Reading file...
Parsing JS...
Finding modules...
Took 5629.809396982193ms
Pre-parsing modules...
 ████████████████████████████████████████ 100% | ETA: 0s | 864/864
Took 3258.959067940712ms
Tagging...
 ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ 0% | ETA: 111s | 1/864
Took 129.05862295627594ms
Filtering out modules only depended on ignored modules...
655 remain to be decompiled
Took 417.321918964386ms
Decompiling...
 ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ 0% | ETA: 5741s | 1/655
Took 8790.68630206585ms
Generating code...
 ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ 0% | ETA: 0s | 0/655
 ████████████████████████████████████████ 100% | ETA: 0s | 655/655
Took 98367.1817688942ms
Saving...
 ████████████████████████████████████████ 100% | ETA: 0s | 655/655
Writing to cache...
Took 2821.761325955391ms
Done!
```

In `output` folder, we can see there are a total of 655 JavaScript files! Jeez, that's a lot. Good news is that most of them are from native libraries and we do not need them. We are only interested in files with main app logics.

Since there's `Admin Account` on login page, we can search for the string in all JavaScript files. We immediately see `443.js` has it. Briefly scanning the whole file, we notice this file has most of the core logics for user login.

### Static Analysis

Now let's take a look at [`443.js`](./443.js). Immediately this function stands out:

```js
e.handleLoginPress = function () {
    if (e.state.email.length === 0) {
        e.setState({
            errorTitle: 'Email Error',
            errorMessage: 'Email Should not be empty',
        });
        e.AlertPro.open();
    } else if (e.state.password.length === 0) {
        e.setState({
            errorTitle: 'Password Error',
            errorMessage: 'Password Should not be empty',
        });
        e.AlertPro.open();
    } else if (module445.validate(e.state.email)) {
        e._verifyEmail(module40.default(e));
    } else {
        e.setState({
            email: '',
            wrongEmail: true,
        });
    }
};
```

Upon clicking `Login` button, the app will check if email and password are empty. If they are not, it will check if the email is valid. If it is, it will call `_verifyEmail` function. Let's take a look at this function. It is quite long so I only pasted core logics here:

```js
e._verifyEmail =
    ((o = module275.default(function* (t) {
        t.setState({
            verifying: true,
        });
        const n = module477.initializeApp(module476.default);
        const o = module485.getDatabase(n);
        if (t.state.email !== 'admin@sekai.team' || e.validatePassword(t.state.password) === false) {
            console.log('Not an admin account.');
        } else {
            console.log('You are an admin...This could be useful.');
        }
        const s = module487.getAuth(n);
        module487
        .signInWithEmailAndPassword(s, t.state.email, t.state.password)
        .then((e) => {
            t.setState({
                verifying: false,
            });
            const n = module485.ref(o, `users/${e.user.uid}/flag`);
            module485.onValue(n, () => {
                t.setState({
                    verifying: false,
                });
                t.setState({
                    errorTitle: 'Hello Admin',
                    errorMessage: "Keep digging, you're almost there!",
                });
                t.AlertPro.open();
            });
        })
        .catch((e) => {
            // A bunch of error handling code
        });
    })));
```

We can see modules info by inspecting the corresponding JavaScript file. For example,

```js
// 478.js
module479.registerVersion('firebase', '9.15.0', 'app');
// 477.js
const c = {
    apiKey: 'AIzaSyCR2Al5_9U5j6UOhqu0HCDS0jhpYfa2Wgk',
    authDomain: 'crackme-1b52a.firebaseapp.com',
    projectId: 'crackme-1b52a',
    storageBucket: 'crackme-1b52a.appspot.com',
    messagingSenderId: '544041293350',
    appId: '1:544041293350:web:2abc55a6bb408e4ff838e7',
    measurementId: 'G-RDD86JV32R',
    databaseURL: 'https://crackme-1b52a-default-rtdb.firebaseio.com',
};
```

So the code essentially calls `firebase.initializeApp` to initialize Firebase, then got the database object and store in `o`. The below part looks important:

```js
if (t.state.email !== 'admin@sekai.team' || e.validatePassword(t.state.password) === false) {
    console.log('Not an admin account.');
} else {
    console.log('You are an admin...This could be useful.');
}
```

Apparently the email is `admin@sekai.team` for admin account. If we input a random password, we indeed see a different error message, meaning the admin user is valid.

Now let's check `validatePassword`:

```js
e.validatePassword = function (e) {
    if (e.length !== 17) {
        return false;
    }
    const t = module700.default.enc.Utf8.parse(module456.default.KEY);
    const n = module700.default.enc.Utf8.parse(module456.default.IV);
    return (
        module700.default.AES.encrypt(e, t, {iv: n,}).ciphertext.toString(module700.default.enc.Hex) === '03afaa672ff078c63d5bdb0ea08be12b09ea53ea822cd2acef36da5b279b9524'
    );
};
```

And here are the modules:

```js
// 456.js
const _ = {
    LOGIN: 'LOGIN',
    EMAIL_PLACEHOLDER: 'user@sekai.team',
    PASSWORD_PLACEHOLDER: 'password',
    BEGIN: 'CRACKME',
    SIGNUP: 'SIGN UP',
    LOGOUT: 'LOGOUT',
    KEY: 'react_native_expo_version_47.0.0',
    IV: '__sekaictf2023__',
};
```

It isn't hard to understand that the password has length 17, and when encrypted with AES given the key and iv, resulting string has a hex value of `03afaa672ff078c63d5bdb0ea08be12b09ea53ea822cd2acef36da5b279b9524`. Use Python to quickly recover the password:

```py
from Crypto.Cipher import AES
from Crypto.Util.Padding import unpad

key = b'react_native_expo_version_47.0.0'
iv = b'__sekaictf2023__'
ct = bytes.fromhex('03afaa672ff078c63d5bdb0ea08be12b09ea53ea822cd2acef36da5b279b9524')
cipher = AES.new(key, AES.MODE_CBC, iv)
pt = cipher.decrypt(ct)

print(unpad(pt, 16).decode())
```

Output is `s3cr3t_SEKAI_P@ss`. Using this password, we can finally login as admin. Where is the flag though? Digging `_verifyEmail` further, we can see after `signInWithEmailAndPassword` succeeds, below code will be called:

```js
const n = module485.ref(o, `users/${e.user.uid}/flag`);
module485.onValue(n, () => {
    t.setState({
        verifying: false,
    });
    t.setState({
        errorTitle: 'Hello Admin',
        errorMessage: "Keep digging, you're almost there!",
    });
    t.AlertPro.open();
});
```

It seems that the flag is stored in the firebase realtime database under `users/${e.user.uid}/flag`. Since `module485` is `firebase`, we can check the documentation to see what the code is doing. It turns out [`firebase.onValue`](https://firebase.google.com/docs/database/web/read-and-write#web_value_events) has an example in documentation:

```js
const starCountRef = ref(db, 'posts/' + postId + '/starCount');
onValue(starCountRef, (snapshot) => {
    const data = snapshot.val();
    updateStarCount(postElement, data);
});
```

In our case, if `snapshot` is passed to the lambda function, `snapshot.val()` should be the flag, hopefully. How do we get that? There are at least 3 ways to solve it:

1. Change the JavaScript code such that `snapshot.val()` is logged to console, then we can directly use `adb logcat` to get the flag. We can also put flag to `errorTitle` or `errorMessage` to show it on screen.

2. Use [Firebase Database REST API](https://firebase.google.com/docs/database/rest/start) to get the flag, since we know `${e.user.uid}` and can directly query the database.

3. Use HTTP intercepting proxy such as Burp Suite to intercept the request and get the flag. (I learned this way from writeups of the challenge)

### Get the flag

Let's go with the first method. Below are the steps:

1. Open `index.android.bundle`, search and find the place where `module485.onValue(n, () => {` is called.

2. Change the code into

```js
module485.onValue(n, (snapshot) => {
    t.setState({
        verifying: false,
    });
    t.setState({
        errorTitle: 'Hello Admin',
        errorMessage: snapshot.val(),
    });
    t.AlertPro.open();
});
```

3. zip the files back and rename it to `CrackMe.apk` (reverse steps of how we unpacked the APK).

4. At this stage, you cannot install the APK normally because it has not been signed. Use [Uber Apk Signer](https://github.com/patrickfav/uber-apk-signer) to sign the APK so it has valid signature. I first used `jarsigner` and spent a long time on getting it installed, but it turns out `base.apk` is signed with signature v2 while jarsigner only supports v1. After this step you would get `CrackMe-aligned-debugSigned.apk`.

5. Install the APK. For my own device, I still cannot open the APK for some reason and I think it keeps crashing. We can use `adb` on emulator and see what's the error:

```bash
D:\>adb install CrackMe.apk
Performing Streamed Install
adb: failed to install CrackMe.apk: Failure [-124: Failed parse during installPackageLI: Targeting R+ (version 30 and above) requires the resources.arsc of installed APKs to be stored uncompressed and aligned on a 4-byte boundary]
```

6. Now that we know the issue, install the APK on emulator with API version lower than 30, and it can be opened successfully. Enter `admin@sekai.team` as email and `s3cr3t_SEKAI_P@ss` as password, and we can see the flag.

Flag: `SEKAI{15_React_N@71v3_R3v3rs3_H@RD???}`

The challenge is straightforward in analysing and getting the flag. The only tricky part is to get the flag from Firebase database, which can be done in multiple ways.

### Appendix

Firebase realtime database rules:

```json
{
  "rules": {
    "flag": {
      ".read": true,
      ".write": false
    },
    "users": {
      "$uid": {
        ".read": "auth !== null && auth.uid === $uid",
        ".write": false
      }
    }
  }
}
```