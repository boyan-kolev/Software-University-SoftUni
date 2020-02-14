using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer_HTTP
{
    public class StartUp
    {
        static private Dictionary<string, int> SessionStore = new Dictionary<string, int>();
        public static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                int counter = 0;
                if (i == 2)
                {
                    continue;
                }
                else
                {
                    counter++;
                }

                counter++;
            }

            //int count = 0;
            //object lockObj = new object();

            //for (int i = 0; i < 1000000; i++)
            //{
            //    Task.Run(() =>
            //    {
            //        lock (lockObj)
            //        {
            //            count++;
            //        }
            //    });
            //}

            //Thread.Sleep(10000);

            //Console.WriteLine(count);


            //            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            //            tcpListener.Start();

            //            while (true)
            //            {
            //                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
            //#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            //                Task.Run(() => ProcessClientAsync(tcpClient));
            //#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            //            }
        }

        private static async Task ProcessClientAsync(TcpClient tcpClient)
        {
            const string NewLine = "\r\n";
            using NetworkStream networkStream = tcpClient.GetStream();
            byte[] requestBytes = new byte[1000000];
            int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

            
            string cookieSid = Regex.Match(request, @"Cookie: sid=[^\r\n]+").Groups[0].Value.Replace("Cookie: sid=", "").Trim();
            bool isNull = true;

            if (string.IsNullOrWhiteSpace(cookieSid))
            {
                cookieSid = Guid.NewGuid().ToString();
                SessionStore.Add(cookieSid, 1);
                isNull = true;
            }
            else
            {
                SessionStore[cookieSid]++;
                isNull = false;
            }

            string responseText = "<H4>" + SessionStore[cookieSid] + "</H4>";

            string response = "HTTP/1.1 200 OK" + NewLine +
                "Server: SoftUniServer/1.0" + NewLine +
                //"Location: https://softuni.bg" + NewLine +
                //"Content-Disposition: attachment; filename=MySite.html" + NewLine +
                "Content-Type: text/html" + NewLine +
                (isNull ? $"Set-Cookie: sid={cookieSid}; path=/; HttpOnly; Expires=" + new DateTime(2055, 6, 25).ToString("R") + NewLine : string.Empty) +
                "Content-Length: " + responseText.Length + NewLine +
                NewLine + responseText;

            byte[] responsebytes = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responsebytes, 0, responsebytes.Length);

            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));

        }


        public static async Task HttpRequest()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://softuni.bg");
            HttpContent httpContent = responseMessage.Content;
            string pageContent = await httpContent.ReadAsStringAsync();
        }
    }
}
