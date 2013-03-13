using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HttpClientWithSockets
{
    using System.Net;
    using System.Net.Sockets;

    class Program
    {


        static void Main(string[] args)
        {
            String response = MakeHttpRequest(args[0]);
            Console.WriteLine(response);

        }

        private static string MakeHttpRequest(string uriStr)
        {
            Uri requestUri = new Uri(uriStr);
            Socket sock = CreateSocket(requestUri.Host, requestUri.Port);

            String str = String.Format("GET {0} HTTP/1.1\r\nHost:{1}\r\nConnection: close\r\n\r\n",
                    requestUri.ToString(), requestUri.Host 
                );

            sock.Send(ASCIIEncoding.ASCII.GetBytes(str));


            return ReadResponse(sock);

        }

        private static string ReadResponse(Socket sock)
        {
            byte[] buffer = new byte[128];
            StringBuilder str = new StringBuilder();

            while (true)
            {
                int len = sock.Receive(buffer);
                str.Append(ASCIIEncoding.ASCII.GetString(buffer, 0, len));
                if (len < buffer.Length) break;
            }

            return str.ToString();

        }

        private static Socket CreateSocket(string host, int port)
        {
            IPAddress address = Dns.GetHostAddresses(host)[0];

            IPEndPoint endpoint = new IPEndPoint(address, port);

            Socket s = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(endpoint);

            return s;
        }
    }
}
