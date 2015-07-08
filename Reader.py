import re

text = open("bible.txt", "r")
bible = text.read()
sentences = re.split('[\.\!\?]+', bible)
print sentences[0]