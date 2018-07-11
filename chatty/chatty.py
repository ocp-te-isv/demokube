from flask import Flask
import time
import threading

app = Flask(__name__)

@app.route('/')
def root():
    return 'I like to be very verbose with my logs 😇'

@app.route('/health')
def health():
    return ''

def spam():
    print('✅ alert: everything is okay')
    threading.Timer(0.5, spam).start()

spam()