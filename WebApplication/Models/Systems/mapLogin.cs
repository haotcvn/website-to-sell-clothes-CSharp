using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.Systems;

namespace WebApplication.Models.Systems
{
    public class mapLogin
    {
        WebApplicationEntities db = new WebApplicationEntities();
        string username, passwword;
        public bool Login()
        {
            try
            {
                var data = db.KhachHangs.Where(model => model.TenDangNhap.Equals(username) && model.MatKhau.Equals(passwword)).ToList();
                if (data.Count > 0)
                {
                    
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}