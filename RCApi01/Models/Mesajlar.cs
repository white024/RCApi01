using System;
using System.Collections.Generic;

namespace RCApi01.Models
{
    public partial class Mesajlar
    {
        public int MesajNo { get; set; }
        public int IdG { get; set; }
        public string? IdAlici { get; set; }
        public string? KullaniciAdiG { get; set; }
        public string? KullaniciAdiA { get; set; }
        public string Mesaj { get; set; } = null!;
        public string? MessageType { get; set; }
    }
}
