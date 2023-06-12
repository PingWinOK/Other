import json
import requests

api_url = 'https://www.virustotal.com/vtapi/v2/file/report'
params = dict(apikey='dba731e2524faf1f63ff31c98f1a0a815e2e6ff1ebda5171b1cf4a7e4a36013d',resource='a144a1536da0bda7dd4c805835f8964947d9eebf05ffc227af043b3517357571-1653352518')
with open('C:/Users/User/Desktop/Боб/x758mSpGylM.jpg', 'rb') as file:
  files = dict(file=('C:/Users/User/Desktop/Боб/x758mSpGylM.jpg', file))
  response = requests.get(api_url, params=params)
  if response.status_code == 200:
    result = response.json()
    for key in result['scans']:
      print(key)
      print('  Detected: ', result['scans'][key]['detected'])
      print('  Version: ', result['scans'][key]['version'])
      print('  Update: ', result['scans'][key]['update'])
      print('  Result: ', result['scans'][key]['result'])