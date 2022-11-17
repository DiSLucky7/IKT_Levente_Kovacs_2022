using System;
using System.Collections.Generic;

#nullable disable

namespace SakkWebApp.Models
{
    public partial class Figurak
    {
        public int Id { get; set; }
        public string Megnevezes { get; set; }
        public int TablaDb { get; set; }
        public string LepesSzabaly { get; set; }
        public byte[] Image { get; set; }
    }
}
