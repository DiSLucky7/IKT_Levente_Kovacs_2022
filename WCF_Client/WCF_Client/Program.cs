using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WCF_Client.ServiceReference1;

namespace WCF_Client
{
    internal class Program
    {
        public static ServiceReference1.Service1Client kliens;

        public static Kutya EgyKutyaPost()
        {
            Kutya Kutya = new Kutya();
            WebClient client = new WebClient();
            JObject jObject = new JObject();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding = System.Text.Encoding.UTF8;
            string result = client.UploadString("http://localhost:3000/" + "EgyKutyaHozzaAdas", jObject.ToString());
            Console.WriteLine(result);
            Kutya= JsonConvert.DeserializeObject<Kutya>(result);
            return Kutya;
        }
        public static string EgyKutyaAdd(Kutya kutya)
        {
            WebClient client = new WebClient();
            JObject jObject = new JObject();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding = System.Text.Encoding.UTF8;
            string result = client.UploadString("http://localhost:3000/" + "EgyKutyaAdd", jObject.ToString());
            //Console.WriteLine(result);
            return result;
        }

        static void Main(string[] args)
        {
            kliens = new ServiceReference1.Service1Client();

            Kutya kutya = new Kutya();
            kutya.ID = 17;
            kutya.Nev = "Yato";
            kutya.Gazdi = "Mind1";
            kutya.Eletkor = 42;
            kutya.Fajta = "Orosz agár";
            kutya.Neme = true; //még nem döntötte el
            kutya.LabakSzama = 2;
            Console.WriteLine(kliens.EgyKutyaAddCS(kutya));
            Console.WriteLine(EgyKutyaAdd(kutya));

            Kutya ek = kliens.EgyKutyaGetCS();
            Console.WriteLine(ek.Gazdi);
            Kutya egyKutya = EgyKutyaPost();
            Console.WriteLine(egyKutya.Gazdi);
            for (int i = 0; i < 100; i++)
            {
                kliens.EgyKutyaPostCS();
            }
            Console.ReadKey();
            kliens.Close();
        }
    }
}
