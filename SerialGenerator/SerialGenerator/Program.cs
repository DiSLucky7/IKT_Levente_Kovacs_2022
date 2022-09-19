using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGenerator
{
    internal class Program
    {
        static void kapcsolodas()
        {
            Connect c = new Connect();
        }
        static void Main(string[] args)
        {
            kapcsolodas();
            Console.ReadKey();
        }
    }
}
