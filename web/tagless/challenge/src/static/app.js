
document.addEventListener("DOMContentLoaded", function() {

    var displayButton = document.getElementById("displayButton");
    
    displayButton.addEventListener("click", function() {
        displayInput();
    });
});

function sanitizeInput(str) {
    str = str.replace(/<.*>/igm, '').replace(/<\.*>/igm, '').replace(/<.*>.*<\/.*>/igm, ''); 
    return str;
}

function autoDisplay() {
    const urlParams = new URLSearchParams(window.location.search);
    const input = urlParams.get('auto_input');
    displayInput(input);
}

function displayInput(input) {
    const urlParams = new URLSearchParams(window.location.search);
    const fulldisplay = urlParams.get('fulldisplay');

    var sanitizedInput = "";
    if (input) {
        sanitizedInput = sanitizeInput(input);
    } else {
        var userInput = document.getElementById("userInput").value;
        sanitizedInput = sanitizeInput(userInput);
    }
    var iframe = document.getElementById("displayFrame");
    var iframeContent = `
        <!DOCTYPE html>
        <head>
            <title>Display</title>
            <link href="https://fonts.googleapis.com/css?family=Press+Start+2P" rel="stylesheet">
            <style>
                body {
                    font-family: 'Press Start 2P', cursive;
                    color: #212529; 
                    padding: 10px; 
                }
            </style>
        </head>
        <body>
            ${sanitizedInput}
        </body>
    `;
    iframe.contentWindow.document.open('text/html', 'replace');
    iframe.contentWindow.document.write(iframeContent);
    iframe.contentWindow.document.close();

    if (fulldisplay && sanitizedInput) {
        var tab = open("/")
        tab.document.write(iframe.contentWindow.document.documentElement.innerHTML);
    }
}

autoDisplay();