//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KitapShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.Sepet = new HashSet<Sepet>();
        }
    
        public int ur_ID { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string Cevirmen { get; set; }
        public string Yayinevi { get; set; }
        public string Dil { get; set; }
        public string Kapak { get; set; }
        public string Sayfa { get; set; }
        public byte[] Foto { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public Nullable<double> Fiyat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sepet> Sepet { get; set; }
    }
}
