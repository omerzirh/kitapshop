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
    
    public partial class Yorumlar
    {
        public int y_ID { get; set; }
        public string Yorum { get; set; }
        public Nullable<int> uyeID { get; set; }
        public Nullable<int> kitapID { get; set; }
        public Nullable<int> onay { get; set; }
    
        public virtual Uyeler Uyeler { get; set; }
    }
}
