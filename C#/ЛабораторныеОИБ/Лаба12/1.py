from PIL import Image, ImageDraw
from random import randint


def stega_encrypt():
    img = Image.open("15010960986550.png")
    keys = []
    draw = ImageDraw.Draw(img)
    width = img.size[0]
    height = img.size[1]
    pixel = img.load()
    f = open('secret.txt', 'w')
    for i in ([ord(i) for i in 'Kulakov Danil']):
        key = (randint(1, width - 10), randint(1, height - 10))
        g, b = pixel[key][1:3]
        draw.point(key, (i, g, b))
        f.write(str(key) + '\n')
    print('Done')
    img.save("Secretimage.png", "PNG")
    f.close()

stega_encrypt()
