using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        WebApplicationEntities db = new WebApplicationEntities();
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var employee = db.NhanViens.SingleOrDefault(model => model.TenDangNhap.ToLower() == username.ToLower() & model.MatKhau == password);
             
            //1. Kiểm tra tên đăng nhập có trống hay không
            if (string.IsNullOrEmpty(username) == true || string.IsNullOrEmpty(password) == true)
            {
                ViewBag.Erro = "Vui lòng nhập tài khoản hoặc mật khẩu!";
                return View();
            }

            if (username != null)
            {
                Session["user"] = employee;
                ViewBag.user = employee;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        //public ActionResult Login(string username, string password)
        //{
        //    // 1. Kiểm tra tên đăng nhập có trống hay không
        //    if (string.IsNullOrEmpty(username) == true || string.IsNullOrEmpty(password) == true)
        //    {
        //        ViewBag.Erro = "Vui lòng nhập tài khoản và mật khẩu!";
        //        return View();
        //    }

        //    //Lấy tài khoản
        //    var employee = db.NhanViens.SingleOrDefault(model => model.TenDangNhap.ToLower() == username.ToLower());

        //    // Kiểm tra tài khoản có tồn tại hay không
        //    if (employee == null)
        //    {
        //        ViewBag.Erro = "Tài khoản không tồn tại!";
        //        ViewBag.User = username;
        //        return View();
        //    }

            //// Kiểm tra mật khẩu
            //if (password == employee.MatKhau)
            //{
            //    // Đã lưu
            //    Session["user"] = employee;
            //    return RedirectToAction("Index");
            //}
            //ViewBag.Erro = "Mật khẩu không đúng 2!";
        //ViewBag.User = username;
            //return View();
            
        //}

        // Đăng xuất tài khoản
        public ActionResult Logout()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}