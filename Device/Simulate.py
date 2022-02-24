import requests
import json

# Đây là phần chuỗi URL dùng để đưa vào requests (cho đỡ rối này)
url = 'https://localhost:44332/api/DataValues/1' #POST
urlSH = 'https://localhost:5001/api/DataValues/1'

# try:
	# Phần dữ liệu JSON để update cho DeviceSate của requset 
sData = 10
sendDataReq = requests.post(urlSH, json = sData)		# Gửi HTTP request với phương thức POST
print('POST Send Data values: ================================================')
print('URL:     ' + str(updateDSReq.url))
print('STATUS CODE:     ' + str(updateDSReq.status_code))
print('RESPONSE: \n\t\t' + str(updateDSReq.content))
print()

# except:

# 	print('---------------  Co loi xay ra!!!')
# 	print()