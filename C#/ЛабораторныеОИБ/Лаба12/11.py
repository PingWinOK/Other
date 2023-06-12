
from PIL import Image
import sys

def b2a(b):
    s = ''
    while len(b) != 0:
        binbyte = b[:8]  # Get a byte
        s += chr(int(binbyte, 2)) # Convert it
        b = b[9:]  # Skip every 9th bit
    return s

# Load image data
img = Image.open("00001069.png")
w,h = img.size
pixels = img.load()

binary = ''
for y in range(h):
    for x in range(w):
        # Pull out the LSBs of this pixel in RGB order
        binary += ''.join([str(n & 1) for n in pixels[x, y]])
        
f = open('fin.txt', 'w')
f.write(b2a(binary));
f.close
