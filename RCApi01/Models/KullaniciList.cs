using System;
using System.Collections.Generic;

namespace RCApi01.Models
{
    public partial class KullaniciList
    {
        public int IdKullanici { get; set; }
        public string KullaniciAdiU { get; set; } = null!;
        public string Sifre { get; set; } = null!;
        public bool? Durum { get; set; }
    }
}
