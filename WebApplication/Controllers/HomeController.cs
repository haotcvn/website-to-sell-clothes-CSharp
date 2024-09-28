using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.Systems;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        WebApplicationEntities db = new WebApplicationEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Account()
        {
            return View();
        }

        // Đăng nhập tài khoản người dùng
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string passwword)
        {
            if (ModelState.IsValid)
            {
                var fpassword = new mapEncode().CreateMD5(passwword);
                var data = db.KhachHangs.Where(model => model.TenDangNhap.Equals(username) && model.MatKhau.Equals(fpassword)).ToList();
                if (data.Count > 0)
                {
                    Session["username"] = data.FirstOrDefault().TenDangNhap;
                    Session["fullname"] = data.FirstOrDefault().TenKhachHang;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErroL = "Đăng nhập không thành công";
                    return RedirectToAction("Account");
                }
            }
            return RedirectToAction("Account");
        }

        // Đăng ký tài khoản người dùng
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang user)
        {
            if (ModelState.IsValid)
            {
                var check = db.KhachHangs.SingleOrDefault(model => model.TenDangNhap == user.TenDangNhap);
                if (check == null)
                {
                    user.MatKhau = new mapEncode().CreateMD5(user.MatKhau);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErroR = "*Tên người dùng đã tồn tại";
                    return RedirectToAction("Account");
                } 
            }
            return RedirectToAction("Account");
        }
    }
}