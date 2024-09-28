using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Systems;

namespace WebApplication.Controllers
{
    public class ShopController : Controller
    {
        mapProduce map = new mapProduce();

        // 1. Lấy danh sách sản phẩm theo danh mục
        public ActionResult Categories(int ? id)
        {
            ViewBag.MaLoaiSanPham = id;
            return View(new mapProduce().ListByCategories(id));
        }

        // 2. Tìm kiếm sản phẩm theo tên
        public ActionResult Search(string q)
        {
            ViewBag.TenSanPham = q;
            return View(new mapProduce().ListSearch(q));
        }
        
        // 3. Chi tiết sản phẩm
        public ActionResult Details(int id)
        {
            if (map.Details(id) == null)
            {
                return RedirectToAction("Categories");
            }
            else
            {
                ViewBag.MaSanPham = id;
                return View(new mapProduce().Details(id));
            }
        }
    }
}