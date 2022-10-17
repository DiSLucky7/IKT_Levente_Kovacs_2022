using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Payment_wcf
{
    public class Service1 : IService1
    {
        //List<Customer> cust = new List<Customer>();
        //public Customer getCustomer()
        //{
        //    cust.Add(new Customer());
        //    return cust[0];
        //}


        public static List<Customer> customerLista = new List<Customer>();
        Random random = new Random();

        public static HashSet<int> customerIndex = new HashSet<int>();//ID kerül ide

        public static int Pozicio(int id)
        {
            int index = 0;
            int soroSzama = customerLista.Count;
            while (index < soroSzama)
            {
                if (customerLista[index].ID == id)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public Customer CustomerGet()
        {
            Customer customer = new Customer();
            customer.ID = 1;
            customer.Name = "Customer1";
            customer.City = "Miskolc";
            Console.WriteLine("Adatok lekérve...");
            return customer;
        }

        public Customer CustomerGetCS()
        {
            return CustomerGet();
        }

        public Customer CustomerPost()
        {
            Customer customer = new Customer();
            customer.ID = random.Next(1, 10001);
            customer.Name = "Customer2";
            customer.City = "BP";
            customerLista.Add(customer);
            Console.WriteLine("Működik a post");
            return customer;
        }

        public Customer CustomerPostCS()
        {
            return CustomerPost();
        }

        public List<Customer> CustomerkListaja()
        {
            Console.WriteLine("Customerlista lekérve");
            return customerLista;
        }

        public List<Customer> CustomerkListajaCS()
        {
            return CustomerkListaja();
        }

        public string CustomerAddCS(Customer customer)
        {
            if (customer != null && customer.ID != null)
            {
                int id = (int)customer.ID;
                if (!customerIndex.Contains(id))
                {
                    customerLista.Add(customer);
                    customerIndex.Add(id);
                    return "Adat hozzáadása sikeres.";
                }
            }
            return "Az adat hozzáadás sikertelen!";
        }

        public string CustomerAdd(Customer customer)
        {
            Console.WriteLine(customer);
            return CustomerAddCS(customer);
        }

        public string CustomerPutCS(Customer customer)
        {
            if (customer != null && customer.ID != null)
            {
                int id = (int)customer.ID;
                if (customerIndex.Contains(id))
                {
                    int index = Pozicio(id);
                    if (index != -1)
                    {
                        customerLista[index] = customer;
                        return "Adat módosítása sikeres.";
                    }
                }
            }
            return "Adatok módosítása sikertelen";
        }

        public Customer CustomerGetIDCS(int ID)
        {
            if (ID >= 0)
            {
                int id = (int)ID;
                if (customerIndex.Contains(id))
                {
                    int index = Pozicio(id);
                    if (index != -1)
                    {
                        return customerLista[index];
                    }
                }
            }
            return null;
        }

        public string CustomerPut(Customer customer)
        {
            Console.WriteLine(customer);
            return CustomerPutCS(customer);
        }

        public string CustomerPatchCS(Customer customer)
        {
            Console.WriteLine(customer);
            return CustomerPutCS(customer);
        }
        public string CustomerPatch(Customer customer)
        {
            Console.WriteLine(customer);
            return CustomerPutCS(customer);
        }

        public string CustomerDeleteCS(int ID)
        {
            if (ID != null)
            {
                int id = (int)ID;
                if (customerIndex.Contains(id))
                {
                    int index = Pozicio(id);
                    if (index != -1)
                    {
                        customerLista.RemoveAt(index);
                        customerIndex.Remove(id);
                        return "Adat törlése sikeres.";
                    }
                }
            }
            return "Adatok törlése sikertelen";
        }

        public string CustomerDelete(int ID)
        {
            return CustomerDeleteCS(ID);
        }

        public string CustomerDeleteID(int ID)
        {
            return CustomerDeleteCS(ID);
        }

        public Customer CustomerGetID(int ID)
        {
            return CustomerGetIDCS(ID);
        }


    }
}
