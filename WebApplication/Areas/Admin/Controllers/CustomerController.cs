using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.Systems;

namespace WebApplication.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // Tạo database
        WebApplicationEntities db = new WebApplicationEntities();
        mapCustomer map = new mapCustomer();

        public ActionResult List()
        {
            //List<KhachHang> list = db.KhachHangs.ToList();
            return View(map.List());
        }
        // Thêm mới
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KhachHang model)
        {
            if (map.Create(model) == true)
            {
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("", map.message);
                return View(model);
            }
        }
        // Chỉnh sửa
        public ActionResult Edit(int maKhachHang)
        {
            var model = map.Details(maKhachHang);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang model)
        {
            if (map.Edit(model) == true)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }
        // Xóa
        public ActionResult Delete(int maKhachHang)
        {
            if (map.Delete(maKhachHang) == true)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
        // Xóa theo nhóm
        public ActionResult DeleteGroup(int iDLoai)
        {
            // 1. Xóa dữ liệu bảng cần xóa (Loại khách hàng)
            var delete = db.LoaiKhachHangs.Find(iDLoai);

            db.LoaiKhachHangs.Remove(delete);
            db.SaveChanges();

            // 2. Xóa bảng con liên quan:
            var list = db.KhachHangs.Where(model => model.MaLoaiKhachHang == iDLoai).ToList();
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