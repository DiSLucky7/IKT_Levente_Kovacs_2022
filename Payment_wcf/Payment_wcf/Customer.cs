using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Payment_wcf
{
    public class Customer
    {
        [DataMember]
        public int? ID { get; set; }


        [DataMember(IsRequired = true)]
        public string Name { get; set; }


        [DataMember(IsRequired = true)]
        public string City { get; set; }

        public Customer()
        {
            ID = 1;
            Name = "Customer1";
            City = "Miskolc;";
        }
    }
}