//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDatHang
    {
        public int MaDatHang { get; set; }
        public int MaSanPham { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> Gia { get; set; }
        public Nullable<double> TongTien { get; set; }
    
        public virtual DatHang DatHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
