//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class unutulan_sifre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public unutulan_sifre()
        {
            this.kullanici_list = new HashSet<kullanici_list>();
        }
    
        public string user_sifre { get; set; }
        public string unutulan_sifre_a { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kullanici_list> kullanici_list { get; set; }
    }
}
