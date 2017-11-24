using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using RaspberryPi_UdpBroadcastReceiver.MarsvinService;

namespace RaspberryPi_UdpBroadcastReceiver
{
    internal class Program
    {
        //hvad er static? :https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
        // burde vi ha 2 post en post til DB en post til billeder? eller bruge samme metode.

        private const int Port = 7000; // Husk at sikre at Firewall kan modtage indgående og port 7000
        private static readonly IPAddress IpAddress = IPAddress.Any;


        private static string GetBroadcast()
        {
            var remoteEndPoint = new IPEndPoint(IpAddress, 9998);

            using (var socket = new UdpClient(Port))
            {
                var datagramReceived = socket.Receive(ref remoteEndPoint);

                var message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);

                return message;
            }
        }


        private static string CheckForLink()
        {
            //test string
            //var checkmig = "dus skal se dette link igennem for at inde ud https://imgur.com/a/RmGd9 om der er noget vi kan bruge";
            string _strToCheck = GetBroadcast();

            if (_strToCheck.Contains("http"))
                foreach (Match item in Regex.Matches(_strToCheck, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))

                    //linker fx https://imgur.com/a/RmGd9
                    return item.Value;

            //intet link ingen ting.
            return null;
        }


        private static int GennemsnitDB()
        {
            //TODO: lav gennemsnit 
            // 4 er placeholder
            return 4;
        }


        private static void Main(string[] args)
        {
            #region anders

            //int dB;
            //string ImgurLink;

            //using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
            //{
            //    IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);

            //    while (true)
            //    {
            //        Console.WriteLine("Waiting for broadcast " + socket.Client.LocalEndPoint);
            //        byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

            //        string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
            //        Console.WriteLine("Receives " + datagramReceived.Length + " bytes from " + remoteEndPoint.Address + " port " + remoteEndPoint.Port);
            //        Console.WriteLine("Message: " + message);
            //        DecodeMessage(message, out dB, out ImgurLink);

            //        SendDataToWebservice(dB, ImgurLink);
            //    }

            //}

            #endregion

            var Service = new MarsvinServiceClient();

            while (true)
            {
                var _gennemsnit = GennemsnitDB();

                if (_gennemsnit > 50)
                {
                    var _db = GennemsnitDB();
                    var _link = CheckForLink();
                    Console.WriteLine(_link);

                    Service.AddMeasurement(new MarsvinService.Measurement {dB = _db, ImageLink = _link});
                }
                else
                {
                    //på nuværende tidspunkt er "" grundet mangle på ny metode som kun poser db.
                    //metode lavet. dog ikke published samt udkommenteret
                    var _db = GennemsnitDB();
                    Service.AddMeasurement(new MarsvinService.Measurement {dB = _db, ImageLink = ""});
                }

                //så vi ikke bliver ved med køre den samme kode
                Console.WriteLine("slut loop");
                Console.ReadLine();
            }
        }


        #region anders

        //static void DecodeMessage(string message, out int dB, out string ImgurLink)
        //{
        //    string[] parts = message.Split(' ');
        //    dB = Convert.ToInt32(parts[5]);
        //    if (parts.Count() > 6)
        //        ImgurLink = parts[8];
        //    else ImgurLink = "";
        //    Console.WriteLine("dB: "+dB+ " Imgur Link: "+ImgurLink);
        //}


        //static void SendDataToWebservice(int dB, string ImgurLink)
        //{
        //    using (ServiceReference1.LightTempServiceClient refclient =
        //        new LightTempServiceClient("BasicHttpBinding_ILightTempService"))
        //    {
        //        refclient.AddLightTempData(dB,ImgurLink);
        //    }
        //}

        #endregion
    }
}