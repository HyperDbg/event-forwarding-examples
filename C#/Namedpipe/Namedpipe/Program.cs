using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namedpipe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pipe address : \\\\.\\pipe\\HyperDbgTestPipe \nListening...\n");
            var server = new NamedPipeServerStream("HyperDbgTestPipe");
            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            while (true)
            {
                var line = reader.ReadLine();
                Console.Write(line);
            }

        }
    }
}
