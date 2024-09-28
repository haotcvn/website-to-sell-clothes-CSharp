using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Systems
{
    public class mapEmployee
    {
        WebApplicationEntities db = new WebApplicationEntities();

        // 1. Lấy danh sách
        public List<NhanVien> List()
        {
            try
            {
                var list = db.NhanViens.OrderBy(model => model.TenNhanVien).ToList();
                return list;
            }
            catch
            {
                return new List<NhanVien>();
            }
        }

        // 2. Chi tiết
        public NhanVien Details(int maNhanVien)
        {
            try
            {
                return db.NhanViens.Find(maNhanVien);
            }
            catch
            {
                return new NhanVien();
            }
        }

        // 3. Thêm mới
        public int Create(NhanVien create)
        {
            try
            {
                db.NhanViens.Add(create);
                db.SaveChanges();
                return create.MaNhanVien;
            }
            catch
            {
                return 0;
            }
        }

        // 4. Chỉnh sửa
        public bool Edit(NhanVien edit)
        {
            try
            {
                var nhanvien = db.NhanViens.Find(edit.MaNhanVien);
                nhanvien.TenNhanVien = edit.TenNhanVien;
                nhanvien.NgaySinh = edit.NgaySinh;
                nhanvien.GioiTinh = edit.GioiTinh;
                nhanvien.DiaChi = edit.DiaChi;
                nhanvien.SoDienThoai = edit.SoDienThoai;
                nhanvien.Email = edit.Email;
                nhanvien.MaLoaiNhanVien = edit.MaLoaiNhanVien;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 5. Xóa
        public bool Delete(int maNhanVien)
        {
            try
            {
                var nhanvien = db.NhanViens.Find(maNhanVien);

                db.NhanViens.Remove(nhanvien);
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