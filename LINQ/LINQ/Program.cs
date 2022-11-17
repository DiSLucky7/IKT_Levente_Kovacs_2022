using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ1
{
    class termek
    {
        public string nev { get; set; }
        public int db { get; set; }

        public termek(string nev, int db)
        {
            this.nev = nev;
            this.db = db;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //LINQ
            //Lista előkészítése
            List<termek> lista = new List<termek>();
            lista.Add(new termek("alma", 10));
            lista.Add(new termek("alma", 23));
            lista.Add(new termek("körte", 13));
            lista.Add(new termek("körte", 6));
            lista.Add(new termek("tojás", 5));
            lista.Add(new termek("alma", 17));
            lista.Add(new termek("tojás", 25));
            lista.Add(new termek("tojás", 6));
            lista.Add(new termek("tojás", 2));
            lista.Add(new termek("sajt", 25));

            //rendezés order by-al

            //max kiválasztása megadott kulcs szerint

            //almák

            //almák darabszáma

            //maximum
                
            /*
              1. A körték minden adata:
              2. Az összes tétel Fordított ABC rendben:
              3. A tojások darabszám szerint csökkenő sorrendben (OrderByDescendig)
              4. Melyik a körték legelső elleme?
              5. Melyikből van több db körtéből vagy tojásból?        
              */




            Console.ReadLine();


        }
    }
}