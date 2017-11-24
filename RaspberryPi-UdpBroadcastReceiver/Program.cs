using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using RaspberryPi_UdpBroadcastReceiver.ServiceReference1;

namespace RaspberryPi_UdpBroadcastReceiver
{
    class Program
    {
        private const int Port = 7000;   // Husk at sikre at Firewall kan modtage indgående og port 7000


        static void DecodeMessage(string message, out int dB, out string ImgurLink)
        {
            string[] parts = message.Split(' ');
            dB = Convert.ToInt32(parts[5]);
            if (parts.Count() > 6)
                ImgurLink = parts[8];
            else ImgurLink = "";
            Console.WriteLine("dB: "+dB+ " Imgur Link: "+ImgurLink);
        }



        static void SendDataToWebservice(int dB, string ImgurLink)
        {
            using (ServiceReference1.LightTempServiceClient refclient =
                new LightTempServiceClient("BasicHttpBinding_ILightTempService"))
            {
                refclient.AddLightTempData(dB,ImgurLink);
            }
        }








        static void Main(string[] args)
        {
            int dB;
            string ImgurLink;

            using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);

                while (true)
                {
                    Console.WriteLine("Waiting for broadcast "+socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine("Receives "+datagramReceived.Length+" bytes from "+remoteEndPoint.Address+" port "+remoteEndPoint.Port);
                    Console.WriteLine("Message: "+message);
                    DecodeMessage(message, out dB, out ImgurLink);
                    
                    SendDataToWebservice(dB,ImgurLink);
                }

            }

        }

     
    }
}
