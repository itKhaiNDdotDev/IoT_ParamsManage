import requests
import json
import time

# Đây là phần chuỗi URL dùng để đưa vào requests (cho đỡ rối này)
url = 'https://localhost:44332/api/DataValues/1' #POST
urlSH = 'https://localhost:5001/api/DataValues/1'

# try:
# Gui du lieu len server lien tuc lap lai mai trong vong doi thiet bi
while True:
	sData = random.uniform(0.5, 50.0)	#Sinh random gia lap nhiet do phong la so ngau nhien trong khoang 0.5 den 50
	sendDataReq = requests.post(urlSH, json = sData)		# Gửi HTTP request với phương thức POST
	print('POST Send Data values: ================================================')
	print('URL:     ' + str(updateDSReq.url))
	print('STATUS CODE:     ' + str(updateDSReq.status_code))
	print('RESPONSE: \n\t\t' + str(updateDSReq.content))
	print()
	time.sleep(60)	#Cach 1 phut gui du lieu len mot lan

# except:

# 	print('---------------  Co loi xay ra!!!')
# 	print()