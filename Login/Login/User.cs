using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Login
{
    public class User
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Pwd { get; set; }

        [DataMember]
        public string Fullname { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public int Rank { get; set; }

        [DataMember]
        public bool Ban { get; set; }

        [DataMember]
        public DateTime RegTime { get; set; }

        [DataMember]
        public DateTime LogTime { get; set; }

    }
}