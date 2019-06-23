from textblob import TextBlob
import sys

text = sys.argv[1]

blob = TextBlob(text)
response = blob.noun_phrases
if(len(response) > 0):
    print(','.join(response))
else:
    print('')