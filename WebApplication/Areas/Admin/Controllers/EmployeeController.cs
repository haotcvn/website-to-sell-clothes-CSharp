using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.App_Start;
using WebApplication.Models.Systems;

namespace WebApplication.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        WebApplicationEntities db = new WebApplicationEntities();
        public ActionResult List()
        {
            return View(new mapEmployee().List());
        }

        [AdminAuthorize(maChucNang = 2)]
        public ActionResult Create()
        {
            return View();
        }

        [AdminAuthorize(maChucNang = 3)]
        public ActionResult Edit()
        {
            return View();
        }

        [AdminAuthorize(maChucNang = 4)]
        public ActionResult Delete()
        {
            return View();
        }
    }
}