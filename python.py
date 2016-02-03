from __future__ import unicode_literals

import unicodedata

_special_cases = {
    'æ': 'ae',
    'Æ': 'AE',
    'œ': 'oe',
    'Œ': 'OE',
    'þ': 'th',
    'Þ': 'TH',
    'ä': 'ae',
    'Ä': 'AE',
    'ö': 'oe',
    'Ö': 'OE',
    'ü': 'ue',
    'Ü': 'UE',
    'ß': 'ss',
}

def asciify(text):
    text = unicodedata.normalize(text, 'NFC')
    text = ''.join(_special_cases.get(c, c) for c in text)
    text = unicodedata.normalize(text, 'NFD')
    text = ''.join(c for c in text if ord(c) <= 127)
    return text
