using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Systems
{
    public class mapProduce
    {
        WebApplicationEntities db = new WebApplicationEntities();
        public string message = "";
        // 1. Lấy danh sách
        public List<SanPham> List()
        {
            try
            {
                var list = db.SanPhams.OrderBy(model => model.TenSanPham).ToList();
                return list;
            }
            catch
            {
                return new List<SanPham>();
            }
        }

        // 1.1 Lấy danh sách sản phẩm nổi bật nhất tháng
        public List<SanPham> ListOfMonth()
        {
            try
            {
                var list = db.SanPhams.OrderBy(model => model.Gia).Take(3).ToList();
                return list;
            }
            catch
            {
                return new List<SanPham>();
            }
        }

        // 1.2 Lấy danh sách sản phẩm theo danh mục
        public List<SanPham> ListByCategories(int ? maLoaiSanPham)
        {
            try
            {
                var list = (from item in db.SanPhams
                            where item.MaLoaiSanPham == maLoaiSanPham
                            select item
                            ).ToList();
                return list;
            }
            catch
            {
                return new List<SanPham>();
            }
        }

        // 1.3 Lấy danh sách sản phẩm theo tên sản phẩm tìm kiếm
        public List<SanPham> ListSearch(string tenSanPham)
        {
            try
            {
                var list = db.SanPhams.Where(model => model.TenSanPham.ToLower().Contains(tenSanPham.ToLower()) == true || string.IsNullOrEmpty(tenSanPham)).ToList();
                return list.OrderBy(model => model.TenSanPham).ToList();
            }
            catch
            {
                return new List<SanPham>();
            }
        }

        // 1.4 Lấy danh sách sản phẩm liên quan
        public List<SanPham> ListRelate(int maSanPham)
        {
            try
            {
                var item = db.SanPhams.Find(maSanPham);
                return db.SanPhams.Where(model => model.MaSanPham != maSanPham && model.MaLoaiSanPham == item.MaLoaiSanPham).ToList();
            }
            catch
            {
                return new List<SanPham>();
            }
        }

        // 2. Chi tiết
        public SanPham Details(int id)
        {
            try
            {
                return db.SanPhams.Find(id);
            }
            catch
            {
                return new SanPham();
            }
        }

        // 3. Thêm mới
        public bool Create(SanPham model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TenSanPham) == true)
                {
                    message = "Vui lòng nhập đầy đủ thông tin";
                    return false;
                }
                db.SanPhams.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 4. Chỉnh sửa
        public bool Edit(SanPham edit)
        {
            try
            {
                var item = db.SanPhams.Find(edit.MaSanPham);
                if (item == null)
                {
                    return false;
                }
                item.TenSanPham = edit.TenSanPham;
                item.HinhAnh = edit.HinhAnh;
                item.MoTa = edit.MoTa;
                item.ChiTiet = edit.ChiTiet;
                item.Gia = edit.Gia;
                item.SoLuong = edit.SoLuong;
                item.MaLoaiSanPham = edit.MaLoaiSanPham;
                item.TrangThai = edit.TrangThai;
                item.GhiChu = edit.GhiChu;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 5. Xóa
        public bool Delete(int maSanPham)
        {
            try
            {
                var item = db.SanPhams.Find(maSanPham);
                if (item != null)
                {
                    db.SanPhams.Remove(item);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}