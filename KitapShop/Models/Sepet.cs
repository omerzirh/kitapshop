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
    
    public partial class Sepet
    {
        public int s_ID { get; set; }
        public Nullable<int> uyeID { get; set; }
        public Nullable<int> urunID { get; set; }
    
        public virtual Urunler Urunler { get; set; }
        public virtual Uyeler Uyeler { get; set; }
    }
}
