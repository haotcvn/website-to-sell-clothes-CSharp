using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Systems
{
    public class mapTypeCustomer
    {
        WebApplicationEntities db = new WebApplicationEntities();
        public string message = "";
        // 1. Lấy danh sách
        public List<LoaiKhachHang> List()
        {
            try
            {
                var list = db.LoaiKhachHangs.OrderBy(model => model.TenLoaiKhachHang).ToList();
                return list;
            }
            catch
            {
                return new List<LoaiKhachHang>();
            }
        }

        // 2. Chi tiết
        public LoaiKhachHang Details(int maLoaiKhachHang)
        {
            try
            {
                return db.LoaiKhachHangs.Find(maLoaiKhachHang);
            }
            catch
            {
                return new LoaiKhachHang();
            }
        }

        // 3. Thêm mới
        public bool Create(LoaiKhachHang model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TenLoaiKhachHang) == true)
                {
                    message = "Vui lòng nhập đầy đủ thông tin";
                    return false;
                }
                db.LoaiKhachHangs.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 4. Chỉnh sửa
        public bool Edit(LoaiKhachHang edit)
        {
            try
            {
                var item = db.LoaiKhachHangs.Find(edit.MaLoaiKhachHang);
                item.TenLoaiKhachHang = edit.TenLoaiKhachHang;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}