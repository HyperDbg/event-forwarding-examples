﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{
    public static void Main()
    {
        TcpListener server = null;
        try
        {
            //
            // Set the TcpListener on port 50000.
            //
            Int32 port = 50000;

            //
            // Local Ip address
            //
            IPAddress localAddr = IPAddress.Parse("192.168.138.1");

            //
            // TcpListener server = new TcpListener(port);
            //
            server = new TcpListener(localAddr, port);

            //
            // Start listening for client requests.
            //
            server.Start();

            //
            // Buffer for reading data
            //
            Byte[] bytes = new Byte[10000];
            String data = null;

            //
            // Enter the listening loop.
            //
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");

                //
                // Perform a blocking call to accept requests.
                // You could also use server.AcceptSocket() here.
                //
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;

                //
                // Get a stream object for reading and writing
                //
                NetworkStream stream = client.GetStream();

                int i;

                //
                // Loop to receive all the data sent by the client.
                //
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    //
                    // Translate data bytes to a ASCII string.
                    //
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.Write("{0}", data);

                }

                //
                // Shutdown and end connection
                //
                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            //
            // Stop listening for new clients.
            //
            server.Stop();
        }

        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }
}
