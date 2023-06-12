import telebot
import hashlib

token = '916395889:AAF6XO-p_zYzqRU0lnGf5QIdnnpgMGYtjIc'
bot = telebot.TeleBot(token)


@bot.message_handler(commands=['start'])
def start_message(message):
    bot.send_message(message.chat.id, "Закиньте файл!")


@bot.message_handler(content_types=['document'])
def handle_file(message):
    try:
        chat_id = message.chat.id
        file_info = bot.get_file(message.document.file_id)
        downloaded_file = bot.download_file(file_info.file_path)
        src = 'C:/Users/User/Desktop/Боб/received/' + message.document.file_name
        with open(src, 'wb') as new_file:
            new_file.write(downloaded_file)
        bot.reply_to(message, get_digest(src))
    except Exception as e:
        bot.send_message(message.chat.id, e)

@bot.message_handler(content_types=['photo'])
def handle_file(message):
    try:
        chat_id = message.chat.id
        file_info = bot.get_file(message.photo[2].file_id)
        downloaded_file = bot.download_file(file_info.file_path)
        src = 'C:/Users/User/Desktop/Боб/received/' + message.photo[2].file_id + '.png'
        with open(src, 'wb') as new_file:
            new_file.write(downloaded_file)
        bot.reply_to(message, get_digest(src))
    except Exception as e:
        bot.send_message(message.chat.id, e)

def get_digest(file_path):
    HASH = {"Sha256": hashlib.sha256(), "Sha512": hashlib.sha512(), "Sha1": hashlib.sha1(), "MD5": hashlib.md5()}
    s = ''
    for item in HASH.values():
        with open(file_path, 'rb') as file:
            while True:
                chunk = file.read(item.block_size)
                if not chunk:
                    break
                item.update(chunk)
    for key, values in HASH.items():
        s += key + ": " + values.hexdigest() + "\n";
    my_file = open(file.name + ".txt", "w+")
    my_file.write(s)
    my_file.close()
    return s


bot.polling(none_stop=True)
