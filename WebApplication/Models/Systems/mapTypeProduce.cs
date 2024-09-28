using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Systems
{
    public class mapTypeProduce
    {
        WebApplicationEntities db = new WebApplicationEntities();
        public string message = "";
        // 1. Lấy danh sách
        public List<LoaiSanPham> List()
        {
            try
            {
                var list = db.LoaiSanPhams.OrderBy(model => model.TenLoaiSanPham).ToList();
                return list;
            }
            catch
            {
                return new List<LoaiSanPham>();
            }
        }

        // 1.1 Lấy danh sách sản phẩm nổi bật nhất tháng
        public List<LoaiSanPham> ListOfMonth()
        {
            try
            {
                var list = db.LoaiSanPhams.OrderBy(model => model.TenLoaiSanPham).Take(3).ToList();
                return list;
            }
            catch
            {
                return new List<LoaiSanPham>();
            }
        }

        // 2. Chi tiết
        public LoaiSanPham Details(int id)
        {
            try
            {
                return db.LoaiSanPhams.Find(id);
            }
            catch
            {
                return new LoaiSanPham();
            }
        }

        // 3. Thêm mới
        public bool Create(LoaiSanPham model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TenLoaiSanPham) == true)
                {
                    message = "Vui lòng nhập đầy đủ thông tin";
                    return false;
                }
                db.LoaiSanPhams.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 4. Chỉnh sửa
        public bool Edit(LoaiSanPham model)
        {
            try
            {
                var item = db.LoaiSanPhams.Find(model.MaLoaiSanPham);
                if (item == null)
                {
                    return false;
                }
                item.TenLoaiSanPham = model.TenLoaiSanPham;
                item.TrangThai = model.TrangThai;
                item.GhiChu = model.GhiChu;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 5. Xóa
        public bool Delete(int id)
        {
            try
            {
                var item = db.LoaiSanPhams.Find(id);

                db.LoaiSanPhams.Remove(item);
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