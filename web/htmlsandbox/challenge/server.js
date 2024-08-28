const express = require('express');
const puppeteer = require('puppeteer');
const redis = require('redis');
const crypto = require('node:crypto');
const path = require('node:path');

const EVENTS = ["onsearch","onappinstalled","onbeforeinstallprompt","onbeforexrselect","onabort","onbeforeinput","onbeforematch","onbeforetoggle","onblur","oncancel","oncanplay","oncanplaythrough","onchange","onclick","onclose","oncontentvisibilityautostatechange","oncontextlost","oncontextmenu","oncontextrestored","oncuechange","ondblclick","ondrag","ondragend","ondragenter","ondragleave","ondragover","ondragstart","ondrop","ondurationchange","onemptied","onended","onerror","onfocus","onformdata","oninput","oninvalid","onkeydown","onkeypress","onkeyup","onload","onloadeddata","onloadedmetadata","onloadstart","onmousedown","onmouseenter","onmouseleave","onmousemove","onmouseout","onmouseover","onmouseup","onmousewheel","onpause","onplay","onplaying","onprogress","onratechange","onreset","onresize","onscroll","onsecuritypolicyviolation","onseeked","onseeking","onselect","onslotchange","onstalled","onsubmit","onsuspend","ontimeupdate","ontoggle","onvolumechange","onwaiting","onwebkitanimationend","onwebkitanimationiteration","onwebkitanimationstart","onwebkittransitionend","onwheel","onauxclick","ongotpointercapture","onlostpointercapture","onpointerdown","onpointermove","onpointerrawupdate","onpointerup","onpointercancel","onpointerover","onpointerout","onpointerenter","onpointerleave","onselectstart","onselectionchange","onanimationend","onanimationiteration","onanimationstart","ontransitionrun","ontransitionstart","ontransitionend","ontransitioncancel","onafterprint","onbeforeprint","onbeforeunload","onhashchange","onlanguagechange","onmessage","onmessageerror","onoffline","ononline","onpagehide","onpageshow","onpopstate","onrejectionhandled","onstorage","onunhandledrejection","onunload","onpageswap","onpagereveal","onoverscroll","onscrollend","onscrollsnapchange","onscrollsnapchanging","ontimezonechange"];
const EVENT_SELECTOR = EVENTS.map(e=>`*[${e}]`).join(',');


let client;
let browser;
(async () => {
    browser = await puppeteer.launch({
        headless: true,
        pipe: true,
        //dumpio: true,
        args: [
            '--incognito',
            "--no-sandbox",
            "--disable-setuid-sandbox",
            "--js-flags=--noexpose_wasm,--jitless",
        ]
    });
    console.log('init browser');

    client = await redis.createClient({ url: `redis://default@${process.env.REDIS_HOST}:${process.env.REDIS_PORT}` })
        .on('error', err => console.log('Redis Client Error', err))
        .connect();
    console.log('redis connected');
})()


async function validate(url) {
    let valid = false;
    let context;
    try {
        context = await browser.createBrowserContext();
        const page = await context.newPage();
        page.setDefaultTimeout(2000);

        // no shenanigans!
        await page.setJavaScriptEnabled(false);

        // disallow making any requests
        await page.setRequestInterception(true);
        let reqCount = 0;
        page.on('request', interceptedRequest => {
            reqCount++;
            if (interceptedRequest.isInterceptResolutionHandled()) return;
            if (reqCount > 1) {
                interceptedRequest.abort();
            }
            else
                interceptedRequest.continue();
        });

        console.log(`visiting ${url}...`);
        await page.goto(url, { timeout: 3000, waitUntil: 'domcontentloaded' });
        valid = await page.evaluate((s) => {
            // check CSP tag is at the start
            // check no script tags or frames
            // check no event handlers
            return document.querySelector('head').firstElementChild.outerHTML === `<meta http-equiv="Content-Security-Policy" content="default-src 'none'">`
                && document.querySelector('script, noscript, frame, iframe, object, embed') === null && document.querySelector(s) === null
        }, EVENT_SELECTOR) && reqCount === 1;
    }
    catch (e) {
        console.error(e);
    }
    finally {
        if (context) await context.close();
    }
    return valid;
}

// Setup Express
const app = express();
const port = 3000;

app.use(express.urlencoded({ extended: false }));

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, 'index.html'));
})

app.post('/upload', async (req, res) => {
    let html = req.body.html;
    if (!html)
        return res.status(400).send('No html.');
    html = html.trim();
    if (!html.startsWith('<html>'))
        return res.status(400).send('Invalid html.')
    // fast sanity check
    if (!html.includes('<meta http-equiv="Content-Security-Policy" content="default-src \'none\'">'))
        return res.status(400).send('No CSP.');
    html = btoa(html);
    // check again, more strictly...
    if (!await validate('data:text/html;base64,' + html))
        return res.status(400).send('Failed validation.');
    const id = crypto.randomBytes(10).toString('hex');
    await client.set(id, html, { EX: 300 });
    res.send(`<a href="/upload/${id}">File uploaded!</a>`);
});

app.get('/upload/:id', async (req, res) => {
    const id = req.params.id;
    const data = await client.get(id);
    if (!data)
        return res.status(404).send('File not found.');
    const html = Buffer.from(data, 'base64');
    res.end(html);
});

app.listen(port, () => {
    console.log(`Server listening on port ${port}`);
});
