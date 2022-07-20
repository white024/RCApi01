using System;
using System.Collections.Generic;

namespace RCApi01.Models
{
    public partial class YoneticiGiris
    {
        public int IdYGiris { get; set; }
        public string KullaniciAdiA { get; set; } = null!;
        public string Sifre { get; set; } = null!;
        public string? Tur { get; set; }
    }
}
