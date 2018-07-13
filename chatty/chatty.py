from flask import Flask
import os
import sys

app = Flask(__name__)

def important_information(n):
    min_lc = ord(b'a')
    len_lc = 26
    ba = bytearray(os.urandom(n))
    for i, b in enumerate(ba):
        ba[i] = min_lc + b % len_lc # convert 0..255 to 97..122
    return ba.decode("utf-8")

@app.route('/')
def root():
    return 'I like to be very verbose 😇<br/>Here is some stuff you absolutely need to know:<br/>' + important_information(2000000)

@app.route('/health')
def health():
    return ''