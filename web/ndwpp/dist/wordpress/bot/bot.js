const puppeteer = require('puppeteer');
const fs = require('fs');
const path = require('path');

const CONFIG = {
    APPNAME: process.env['APPNAME'] || "Admin",
    APPURL: process.env['APPURL'] || "http://172.17.0.1",
    APPURLREGEX: process.env['APPURLREGEX'] || "^.*$",
    APPFLAG: process.env['APPFLAG'] || "dev{flag}",
    APPLIMITTIME: Number(process.env['APPLIMITTIME'] || "60"),
    APPLIMIT: Number(process.env['APPLIMIT'] || "5"),
    APPEXTENSIONS: (() => {
        const extDir = path.join(__dirname, 'extensions');
        const dir = []
        fs.readdirSync(extDir).forEach(file => {
            if (fs.lstatSync(path.join(extDir, file)).isDirectory()) {
                dir.push(path.join(extDir, file))
            }
        });
        return dir.join(',')
    })()
}


console.table(CONFIG)

function sleep(s) {
    return new Promise((resolve) => setTimeout(resolve, s))
}

function getBrowser() {
    const browserPaths = [
        "/usr/bin/chromium-browser",
        "/usr/bin/google-chrome",
        "/usr/bin/chromium"
    ]
    for (const browserPath of browserPaths) {
        if (fs.existsSync(browserPath)) {
            return browserPath
        }
    }
    throw new Error("No browser found")
}

/**
 * @type {puppeteer.LaunchOptions}
 **/
const browserArgs = {
    executablePath: getBrowser(),
    headless: (()=>{
        const is_x11_exists = fs.existsSync('/tmp/.X11-unix');
        if (process.env['DISPLAY'] !== undefined && is_x11_exists) {
            return false;
        }
        return true;
    })(),
    args: [
        '--disable-dev-shm-usage',
        '--no-sandbox',
        '--disable-setuid-sandbox',
        '--disable-gpu',
        '--no-gpu',
        '--disable-default-apps',
        '--disable-translate',
        '--disable-device-discovery-notifications',
        '--disable-software-rasterizer',
        '--disable-xss-auditor',
        ...(() => {
            if (CONFIG.APPEXTENSIONS === "") return [];
            return [
                `--disable-extensions-except=${CONFIG.APPEXTENSIONS}`,
                `--load-extension=${CONFIG.APPEXTENSIONS}`
            ]
        })(),
    ],
    ignoreHTTPSErrors: true
}
/**
 * @type {puppeteer.Browser}
 */
var initBrowser = null;

console.log("Bot started...");

module.exports = {
    name: CONFIG.APPNAME,
    urlRegex: CONFIG.APPURLREGEX,
    rateLimit: {
        windowS: CONFIG.APPLIMITTIME,
        max: CONFIG.APPLIMIT
    },
    bot: async (urlToVisit) => {
        var context = null;
        // use the same browser instance for all bots if no extensions are loaded
        if (CONFIG.APPEXTENSIONS === "") {
            if (initBrowser === null) {
                initBrowser = await puppeteer.launch(browserArgs);
            }
            context = await initBrowser.createBrowserContext();
        }
        // create a new browser instance for each bot if extensions are loaded
        // this is because puppeteer does not add the extensions to new browser contexts
        if (CONFIG.APPEXTENSIONS !== "") {
            context = (await puppeteer.launch(browserArgs)).defaultBrowserContext();
        }
        try {
            const page = await context.newPage();

            console.log(`bot visiting ${urlToVisit}`)

            await page.goto(urlToVisit, {
                waitUntil: 'networkidle2'
            });

            await sleep(5000);

            console.log("browser close...")
            return true;
        } catch (e) {
            console.error(e);
            return false;
        } finally {
            if (CONFIG.APPEXTENSIONS !== "") {
                await context.browser().close();
            } else {
                await context.close();
            }
        }
    }
}
