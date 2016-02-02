from __future__ import unicode_literals

import unicodedata

_special_cases = {
    'œ': 'OE',
}

def asciify(text):
    text = unicodedata.normalize(text, 'NFC')
    text = ''.join(_special_cases.get(c, c) for c in text)
    text = unicodedata.normalize(text, 'NFD')
    text = ''.join(c for c in text if ord(c) <= 127)
    return text
