using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Systems
{
    public class mapCustomer
    {
        WebApplicationEntities db = new WebApplicationEntities();
        public string message = "";
        // 1. Lấy danh sách
        public List<KhachHang> List()
        {
            try
            {
                var list = db.KhachHangs.OrderBy(model => model.TenKhachHang).ToList();
                return list;
            }
            catch
            {
                return new List<KhachHang>();
            }
        }

        // 2. Chi tiết
        public KhachHang Details(int maKhachHang)
        {
            try
            {
                return db.KhachHangs.Find(maKhachHang);
            }
            catch
            {
                return new KhachHang();
            }
        }

        // 3. Thêm mới
        public bool Create(KhachHang model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TenKhachHang) == true)
                {
                    message = "Vui lòng nhập đầy đủ thông tin";
                    return false;
                }
                db.KhachHangs.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 4. Chỉnh sửa
        public bool Edit(KhachHang edit)
        {
            try
            {
                var item = db.KhachHangs.Find(edit.MaKhachHang);
                if (item == null)
                {
                    return false;
                }
                item.TenKhachHang = edit.TenKhachHang;
                item.NgaySinh = edit.NgaySinh;
                item.GioiTinh = edit.GioiTinh;
                item.DiaChi = edit.DiaChi;
                item.SoDienThoai = edit.SoDienThoai;
                item.Email = edit.Email;
                item.TenDangNhap = edit.Email;
                item.MatKhau = edit.MatKhau;
                item.TrangThai = edit.TrangThai;
                item.MaLoaiKhachHang = edit.MaLoaiKhachHang;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 5. Xóa
        public bool Delete(int maKhachHang)
        {
            try
            {
                var khachhang = db.KhachHangs.Find(maKhachHang);

                db.KhachHangs.Remove(khachhang);
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