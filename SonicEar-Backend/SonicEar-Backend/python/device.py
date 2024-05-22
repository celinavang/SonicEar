import requests
import json
import random
import time
import pyaudio
import audioop 
import math
import pygame

api_url = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement"
thirdparty_url = "http://worldtimeapi.org/api/timezone/Europe/Copenhagen"

headers =  {"Content-Type":"application/json"}
device_id = 1
lastsend = 1;

p = pyaudio.PyAudio()
WIDTH = 2
RATE = int(p.get_default_input_device_info()['defaultSampleRate'])
DEVICE = p.get_default_input_device_info()['index']
rms = 1

def callback(in_data, frame_count, time_info, status):
    global rms
    rms = audioop.rms(in_data, WIDTH) / 32767
    return in_data, pyaudio.paContinue


def checkNumber(number):
    if (number < 20): return {"upper": 20, "lower": 0, "color": "#29a8df"}
    elif (number < 40): 
        return {"upper": 40, "lower": 20, "color": "#3fa5b1"}
    elif (number < 60): 
        return {"upper": 60, "lower": 40, "color": "#54a383"}
    elif (number < 75): 
        return {"upper": 75, "lower": 60, "color": "#66a15d"}
    elif (number < 80):
        return {"upper": 80, "lower": 75, "color": "#9bbb66"}
    elif (number < 90):
        return {"upper": 90, "lower": 80, "color": "#ffc454"}
    elif (number < 100):
        return {"upper": 100, "lower": 90, "color": "#f8ad3a"}
    elif (number < 115):
        return {"upper": 115, "lower": 100, "color": "#e77f38"}
    elif (number < 130):
        return {"upper": 130, "lower": 115, "color": "#e2682d"}
    else: 
        return {"upper": 140, "lower": 130, "color": "#d95139"}


lastsend = 30

def send():

    global lastsend

    if (rms != 0):
        db = 20 * math.log10(rms / 20e-6)

    date = requests.get(thirdparty_url)
    date = json.loads(date.content)
    print(db)
    number = random.randint(1,140)

    getRef = checkNumber(lastsend)
    screen.fill(getRef["color"])
    # check there is any noise
    if (number > 5):
        
        if number > getRef["upper"] or number < getRef["lower"]:
            data = {"id":0,"deviceId":device_id,"device":{"id":0,"location":"string"},"timeStamp":date["datetime"],"noiseLevel":number}
            response = requests.post(api_url, data=json.dumps(data), headers=headers)
            lastsend = number
            response.status_code
            response.json()
        else: print("not changed " + str(number) + " - " + str(lastsend) )
    


stream = p.open(format=p.get_format_from_width(WIDTH),
        input_device_index=DEVICE,
        channels=1,
        rate=RATE,
        input=True,
        output=False,
        stream_callback=callback)

stream.start_stream()


# pygame setup
pygame.init()
screen = pygame.display.set_mode((320, 240))
clock = pygame.time.Clock()
running = True

pygame.display.toggle_fullscreen()

while True:
    send()

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
    
    pygame.display.flip()
    
    time.sleep(1)
pygame.quit()