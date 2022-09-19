using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGenerator
{
    internal class Program
    {
        static void adatbazisMuveletek()
        {
            Connect c = new Connect();
            c.querySelect();
        }
        static void Main(string[] args)
        {
            adatbazisMuveletek();
            Console.ReadKey();
        }
    }
}
