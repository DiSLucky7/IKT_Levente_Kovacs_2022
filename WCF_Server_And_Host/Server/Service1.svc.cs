using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
    public class Service1 : IService1
    {
        public static List<Kutya> kutyaLista = new List<Kutya>();
        Random random = new Random();
        public Kutya EgyKutyaGet()
        {
            Kutya kutya = new Kutya();
            kutya.ID = 1;
            kutya.Nev = "Buksi";
            kutya.Eletkor = 5;
            kutya.Fajta = "Husky";
            kutya.Neme = null;//még nem döntötte el
            kutya.Gazdi = "Kin Csung Csin Leng";
            kutya.LabakSzama = 4;
            Console.WriteLine("Adatok lekérve...");
            return kutya;
        }

        public Kutya EgyKutyaGetCS()
        {
            return EgyKutyaGet();
        }

        public Kutya EgyKutyaPost()
        {
            Kutya kutya = new Kutya();
            kutya.ID = random.Next(1, 10001);
            kutya.Nev = "Buksi IV.";
            kutya.Eletkor = 10;
            kutya.Fajta = "Csivava";
            kutya.Neme = false;//még nem döntötte el
            kutya.Gazdi = "Kun Ben Csin Leng Fing";
            kutya.LabakSzama = 2;
            kutyaLista.Add(kutya);
            Console.WriteLine("Működik a post");
            return kutya;
        }
        public Kutya EgyKutyaPostCS()
        {
            return EgyKutyaPost();
        }

        public List<Kutya> KutyakListaja()
        {
            Console.WriteLine("Kutyalista lekérve");
            return kutyaLista;
        }

        public List<Kutya> KutyakListajaCS()
        {
            return KutyakListaja();
        }

        public string EgyKutyaAdd(Kutya kutya)
        {
            return EgyKutyaAddCS(kutya);
        }

        public string EgyKutyaAddCS(Kutya kutya)
        {
            kutyaLista.Add(kutya);
            return "Adat hozzáadása sikeres.";
        }
    }
}
