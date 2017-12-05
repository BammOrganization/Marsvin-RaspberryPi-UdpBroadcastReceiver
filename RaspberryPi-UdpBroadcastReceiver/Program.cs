using System;
using System.Collections.Generic;
using System.Linq;
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




        private static void GetAverageAndLink(out int average, out string link)
        {
            var remoteEndPoint = new IPEndPoint(IpAddress, 9998);
            //string templink = "";
            //List<int> list = new List<int>(); // new list i clean           

            using (var socket = new UdpClient(Port))
            {
                //for (int i = 0; i < 5; i++)
                //{
                    var datagramReceived = socket.Receive(ref remoteEndPoint);
                    var message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                   // if (String.IsNullOrEmpty(templink))
                     //   templink = CheckForLink(message);
                    //list.Add(GetDb(message));
                    //Console.WriteLine("Måling: " + list[i] + " Link: " + templink);
                link = CheckForLink(message);
                average = GetDb(message);
                Console.WriteLine("Måling: " + average + " Link: " + link);
            //}
               // double averageDouble = list.Average();
                //average = Convert.ToInt32(averageDouble);
                //link = templink;
                //list.Clear();                
            }
        }




        private static string CheckForLink(string _strToCheck)
        {
            //test string
            //var checkmig = "dus skal se dette link igennem for at inde ud https://imgur.com/a/RmGd9 om der er noget vi kan bruge";            

            if (_strToCheck.Contains("http"))
                foreach (Match item in Regex.Matches(_strToCheck, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))

                    //linker fx https://imgur.com/a/RmGd9
                    return item.Value;

            //intet link ingen ting.
            return null;
        }


        private static int GetDb(string _strToCheck)
        {         
            string[] parts = _strToCheck.Split(' ');
            return Convert.ToInt32(parts[5]);           // 5. plads i string er dB        
        }

        //Benjamin
        //private static int GennemsnitDB()
        //{ 

        //    while (true)
        //    {
        //        List<int> list = new List<int>();
        //        double avergedb;
        //        int returndb;

                
        //        for (int i = 0; i < 5; i++)
        //        {
        //            int currentDb = GetDb();
                    
        //            list.Add(currentDb);
        //        }
        //        avergedb =  list.Average();
        //        returndb = Convert.ToInt32(avergedb);
        //        foreach (var item in list)
        //        {
        //            Console.WriteLine("Måling: " + item);
        //        }
        //        list.Clear();
        //        return returndb;
                
        //    }

        //}






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

            Console.WriteLine("Åbner klient (husk at køre samme netværk som Raspberry Pi)");

            var Service = new MarsvinServiceClient();

            Console.WriteLine("Klar til at modtage");
            while (true)
            {
                GetAverageAndLink(out int _gennemsnit, out string _link);
                Console.WriteLine("Link: "+_link);
                Console.WriteLine("Beregning: " + _gennemsnit);

                if (_link != null) //(_gennemsnit >= 50)
                {  
                    Service.AddMeasurement(new MarsvinService.Measurement {dB = _gennemsnit, ImageLink = _link});
                }
                else
                {
                    Service.AddMeasurementNoLink(new MarsvinService.Measurement {dB = _gennemsnit});
                }
                
                Console.WriteLine("Slut loop");
                
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