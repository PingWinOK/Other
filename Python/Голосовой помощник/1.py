import datetime
import sys
from datetime import datetime, date, time
import pyttsx3, time
import pyaudio
import speech_recognition as speech_r
import speech_recognition
import wave
import pyttsx3
import os
import subprocess


class Artem:  # определение класса Артем
    def say(self, text):
        tts = pyttsx3.init()
        tts.setProperty('rate', 150)
        # 180
        volume = tts.getProperty('volume')  # Громкость голоса
        tts.setProperty('volume', 40)
        voices = tts.getProperty('voices')
        # Задать голос по умолчанию
        tts.setProperty('voice', 'ru')
        # Попробовать установить предпочтительный голос
        for voice in voices:
            if voice.name == 'Artemiy':
                tts.setProperty('voice', voice.id)
        tts.say(text)
        tts.runAndWait()

    def time(self):
        tts = pyttsx3.init()
        tts.setProperty('rate', 150)
        # 180
        volume = tts.getProperty('volume')  # Громкость голоса
        tts.setProperty('volume', 40)
        voices = tts.getProperty('voices')
        # Задать голос по умолчанию
        tts.setProperty('voice', 'ru')
        # Попробовать установить предпочтительный голос
        for voice in voices:
            if voice.name == 'Artemiy':
                tts.setProperty('voice', voice.id)
        time = datetime.now()
        tts.say(time.strftime("%H:%M"))
        tts.runAndWait()

    def Program(self, text):
        tts = pyttsx3.init()
        tts.setProperty('rate', 150)
        volume = tts.getProperty('volume')
        tts.setProperty('volume', 40)
        voices = tts.getProperty('voices')
        tts.setProperty('voice', 'ru')
        for voice in voices:
            if voice.name == 'Artemiy':
                tts.setProperty('voice', voice.id)
        if (text == "браузер"):
            os.startfile(r'E:/Vivaldi/Application/vivaldi.exe')
            tts.say("Запуск браузера")

    def off(self):
        sys.exit()


def Rec():
    with microphone as audio_file:
        print("Speak Please")
        recog.adjust_for_ambient_noise(audio_file)
        audio = recog.listen(audio_file)
        print("Converting Speech to Text...")
        try:
            SPEECH = recog.recognize_google(audio, language="ru-RU")
            print("You said: " + SPEECH)
            return SPEECH
        except Exception as e:
            print("Error: " + str(e))


SPEECH = ""
Artem = Artem()
microphone = speech_recognition.Microphone()
recog = speech_recognition.Recognizer()

while True:
    SPEECH = Rec()
    print(SPEECH)
    try:
        if (SPEECH.find("Артём") != -1):
            print("Готов выполнять команду")
            Artem.say("Готов выполнять команду")
            while True:
                SPEECH = Rec()
                try:
                    if (SPEECH.find("время") != -1):
                        print("время")
                        Artem.time()
                    if (SPEECH.find("отбой") != -1):
                        print("отбой")
                        Artem.say("Есть")
                        break
                    if (SPEECH.find("браузер") != -1):
                        print("браузер")
                        Artem.Program("браузер")
                    if (SPEECH.find("выход") != -1):
                        print("выход")
                        Artem.say("Есть")
                        Artem.off()
                    if (SPEECH.find("смена пользователя") != -1):
                        print("смена пользователя")
                        Artem.say("Есть")
                        winpath = os.environ["windir"]
                        os.system(winpath + r'\system32\rundll32 user32.dll, LockWorkStation')
                except Exception as e:
                    print("Error: " + str(e))
    except Exception as e:
        ...
"""
while True:
    with microphone as audio_file:
        print("Speak Please")

        recog.adjust_for_ambient_noise(audio_file)
        audio = recog.listen(audio_file)

        print("Converting Speech to Text...")
        try:
            SPEECH = recog.recognize_google(audio, language="ru-RU")
            print("You said: " + SPEECH)
            if (SPEECH.find("Артём") != -1):
                print("Готов выполнять команду")
                Artem.say("Готов выполнять команду")
                print("Команда")
                audio = recog.listen(audio_file)
                SPEECH = recog.recognize_google(audio, language="ru-RU")
                print("Команда: " + SPEECH)
                if (SPEECH.find("время") != -1):
                    Artem.time()
        except Exception as e:
            print("Error: " + str(e))
"""
