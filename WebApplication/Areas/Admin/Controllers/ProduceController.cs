using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.Systems;

namespace WebApplication.Areas.Admin.Controllers
{
    public class ProduceController : Controller
    {
        mapProduce map = new mapProduce();

        public ActionResult List()
        {
            return View(map.List());
        }

        // Thêm mới
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham model)
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
        public ActionResult Edit(int id)
        {
            var model = map.Details(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham model)
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
        public ActionResult Delete(int id)
        {
            if (map.Delete(id) == true)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
    }
}