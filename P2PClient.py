import requests
import socket

api_url = "http://localhost:53531/api/FileEndpoints"

response = requests.get(api_url)
data = response.json()

fileName = data[0]
print(fileName)

response = requests.get(api_url + "/" + fileName)
data = response.json()

serverIP = data[0]["ipAddress"]
serverPort = data[0]["port"]

#serverIP = "localhost"
#serverPort = 7000
#fileName = "test.exe"

my_socket = socket.socket()
my_socket.connect((serverIP, serverPort))
my_socket.send(fileName.encode())

file = open('c:/temp/output/' + fileName, 'wb')

file_data = my_socket.recv(1024)
while (file_data):
    print("Receiving...")
    file.write(file_data)
    file_data = my_socket.recv(1024)
file.close()

print("Done Sending")
my_socket.close()
