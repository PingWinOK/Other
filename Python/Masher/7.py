from pydub import AudioSegment
import os


command = "trackmix --source ""Mash"" --count 2"
co = command.split(' ')

Source = co[2]
cou = int(co[4])

file_in_dir = os.listdir(path=Source)
songs = []
count = 1
print(file_in_dir)
for i in file_in_dir:
    if cou < count:
        break
    else:
        song = AudioSegment.from_mp3(""+Source+"/"+i+"")
        first_10_seconds = song[:10000]
        songs.append(first_10_seconds)
        count += 1
Track_mix = songs[0]
songs.pop(0)
for i in songs:
    Track_mix += i
Track_mix.export(""+Source+"/Mix.mp3", format="mp3")
