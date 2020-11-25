#!/usr/bin/env python3

import socket

HOST = '192.168.138.1'  # Standard loopback interface address (localhost)
PORT = 50000            # Port to listen on (non-privileged ports are > 1023)

type("text".encode("utf-8"))

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    print('Listening on port ' + str(PORT) + ' ')
    s.listen()
    conn, addr = s.accept()
    with conn:
        print('Connected by', addr)
        while True:
            data = conn.recv(1024)
            print(str(data,'utf-8'), end='')
