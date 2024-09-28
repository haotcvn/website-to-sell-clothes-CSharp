using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        // Tạo database
        WebApplicationEntities db = new WebApplicationEntities();

        // GET: Customer
        public ActionResult GetList()
        {
            List<KhachHang> list = db.KhachHangs.ToList();
            return View(list);
        }
        // Thêm mới
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KhachHang model)
        {
            db.KhachHangs.Add(model);
            db.SaveChanges();
            return RedirectToAction("GetList");
        }
        // Chỉnh sửa
        public ActionResult Edit(int id)
        {
            KhachHang model = db.KhachHangs.Find(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang model)
        {
            var update = db.KhachHangs.Find(model.MaKhachHang);

            update.TenKhachHang = model.TenKhachHang;
            update.SoDienThoai = model.SoDienThoai;
            update.DiaChi = model.DiaChi;
            update.MaLoai = model.MaLoai;
            db.SaveChanges();
            return RedirectToAction("GetList");
        }
        // Xóa
        public ActionResult Delete(int id)
        {
            var update = db.KhachHangs.Find(id);

            db.KhachHangs.Remove(update);
            db.SaveChanges();
            return RedirectToAction("GetList");
        }
        // Xóa theo nhóm
        public ActionResult DeleteGroup(int iDLoai)
        {
            // 1. Xóa dữ liệu bảng cần xóa (Loại khách hàng)
            var delete = db.LoaiKhachHangs.Find(iDLoai);

            db.LoaiKhachHangs.Remove(delete);
            db.SaveChanges();

            // 2. Xóa bảng con liên quan:
            var list = db.KhachHangs.Where(model => model.MaLoai == iDLoai).ToList();
            db.KhachHangs.RemoveRange(list);
            db.SaveChanges();

            // 3. Xóa lẻ
            foreach (var item in list)
            {
                if (item.DiaChi == "Cần Thơ")
                {
                    db.KhachHangs.Remove(item);
                }
            }
            db.SaveChanges();

            return RedirectToAction("GetList");
        }
    }
}