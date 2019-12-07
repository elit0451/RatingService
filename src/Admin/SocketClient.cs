using System;
using System.IO;
using System.Net.Sockets;

namespace Admin
{
    public class SocketClient
    {
        public static void Run()
        {
            new SocketClient().Start();
        }

        public void Start()
        {
            TcpClient server = new TcpClient("localhost", 12345);

            string serverMessage = "";

            while (serverMessage != "exit")
            {
                NetworkStream stream = server.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);

                writer.AutoFlush = true;

                Console.WriteLine("Command:");
                writer.WriteLine(Console.ReadLine());
                serverMessage = reader.ReadLine();
                
                Console.WriteLine(serverMessage);
            }

            Console.ReadKey();
        }
    }
}