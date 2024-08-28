// npm i puppeteer
// script to emulate admin bot

const puppeteer = require("puppeteer");

const FLAG = "SEKAI{test_flag}";
const SITE = "https://htmlsandbox.chals.sekai.team";
const target = process.argv[2];


const visit = async (url) => {
    let browser;
    try {
        browser = await puppeteer.launch({
            headless: true,
            pipe: true,
            args: [
                "--no-sandbox",
                "--disable-setuid-sandbox",
                "--js-flags=--noexpose_wasm,--jitless",
            ],
            dumpio: true
        });

        let page = await browser.newPage();
        await page.goto(SITE, { timeout: 3000, waitUntil: 'domcontentloaded' });

        await page.evaluate((flag) => {
            localStorage.setItem("flag", flag);
        }, FLAG);

        await page.close();
        page = await browser.newPage();

        await page.goto(url, { timeout: 3000, waitUntil: 'domcontentloaded' })
        await new Promise((res)=>setTimeout(res, 3000));

        await browser.close();
        browser = null;
    } catch (err) {
        console.log(err);
    } finally {
        if (browser) await browser.close();
    }
};


if (target.startsWith('https://') || target.startsWith("http://")) {
    visit(target);
}
