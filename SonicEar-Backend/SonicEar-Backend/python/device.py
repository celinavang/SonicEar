import requests
import json
import random

api_url = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement"

thirdparty_url = "http://worldtimeapi.org/api/timezone/Europe/Copenhagen"
device_id = 1

date = requests.get(thirdparty_url)
date = json.loads(date.content)
number = random.randint(1,100)
todo = {"id":0,"deviceId":device_id,"device":{"id":0,"location":"string"},"timeStamp":date["datetime"],"noiseLevel":number}

headers =  {"Content-Type":"application/json"}

response = requests.post(api_url, data=json.dumps(todo), headers=headers)

response.status_code
response.json()