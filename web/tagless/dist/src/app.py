from flask import Flask, render_template, make_response,request
from bot import *
from urllib.parse import urlparse

app = Flask(__name__, static_folder='static')

@app.after_request
def add_security_headers(resp):
    resp.headers['Content-Security-Policy'] = "script-src 'self'; style-src 'self' https://fonts.googleapis.com https://unpkg.com 'unsafe-inline'; font-src https://fonts.gstatic.com;"
    return resp


@app.route('/')
def index():
    return render_template('index.html')

@app.route("/report", methods=["POST"])
def report():
    bot = Bot()
    url = request.form.get('url')
    if url:
        try:
            parsed_url = urlparse(url)
        except Exception:
            return {"error": "Invalid URL."}, 400
        if parsed_url.scheme not in ["http", "https"]:
            return {"error": "Invalid scheme."}, 400
        if parsed_url.hostname not in ["127.0.0.1", "localhost"]:
            return {"error": "Invalid host."}, 401
        
        bot.visit(url)
        bot.close()
        return {"visited":url}, 200
    else:
        return {"error":"URL parameter is missing!"}, 400
    
@app.errorhandler(404)
def page_not_found(error):
    path = request.path
    return f"{path} not found"



if __name__ == '__main__':
    app.run(debug=True)
