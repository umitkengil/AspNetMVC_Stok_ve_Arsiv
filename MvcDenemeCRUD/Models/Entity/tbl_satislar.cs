//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcDenemeCRUD.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_satislar
    {
        public int satis_id { get; set; }
        public int urun { get; set; }
        public int musteri { get; set; }
        public byte adet { get; set; }
        public decimal fiyati { get; set; }
        public byte statu { get; set; }
    
        public virtual tbl_musteriler tbl_musteriler { get; set; }
        public virtual tbl_urunler tbl_urunler { get; set; }
    }
}
