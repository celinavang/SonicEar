import requests
import json
import random
import time
import pyaudio
import audioop  
from math import log10

api_url = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement"

thirdparty_url = "http://worldtimeapi.org/api/timezone/Europe/Copenhagen"
device_id = 1

p = pyaudio.PyAudio()

WIDTH = 2
RATE = int(p.get_default_input_device_info()['defaultSampleRate'])
DEVICE = p.get_default_input_device_info()['index']
rms = 1.1
print(p.get_default_input_device_info())

def callback(in_data, frame_count, time_info, status):
    global rms
    rms = audioop.rms(in_data, WIDTH) / 32767
    return in_data, pyaudio.paContinue




def send():
    stream = p.open(format=p.get_format_from_width(WIDTH),
        input_device_index=DEVICE,
        channels=1,
        rate=RATE,
        input=True,
        output=False,
        stream_callback=callback)

    stream.start_stream()
    while stream.is_active(): 
        db = 20 * log10(rms)
        db = db*-1
        print(f"RMS: {rms} DB: {db}") 
        # refresh every 0.3 seconds 
        time.sleep(0.3)

    date = requests.get(thirdparty_url)
    date = json.loads(date.content)

    number = random.randint(1,100)

    if (number > 5):
        data = {"id":0,"deviceId":device_id,"device":{"id":0,"location":"string"},"timeStamp":date["datetime"],"noiseLevel":number}

        headers =  {"Content-Type":"application/json"}

        response = requests.post(api_url, data=json.dumps(data), headers=headers)

        response.status_code
        response.json()
    
while True:
    send()
    time.sleep(300)