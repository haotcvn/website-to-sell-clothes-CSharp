using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.Systems;

namespace WebApplication.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Shopping()
        {
            var cart = Session["cart"];
            var list = new List<ChiTietDatHang>();
            if (cart != null)
            {
                list = (List<ChiTietDatHang>)cart;
            }
            return View(list);
        }

        // Thêm sản phẩm vào giỏ hàng
        public ActionResult CartItem(int id, int quantity)
        {
            var cart = Session["cart"];
            if (cart != null)
            {
                var list = (List<ChiTietDatHang>)cart;
                if (list.Exists(m => m.MaSanPham == id))
                {
                    foreach (var item in list)
                    {
                        if (item.MaSanPham == id)
                        {
                            item.SoLuong += quantity;
                        }
                    }
                }
                else
                {
                    // Tạo đối tượng 
                    var item = new ChiTietDatHang();
                    item.MaSanPham = id;
                    item.SoLuong = quantity;
                    list.Add(item);
                }

                // Gán vào session
                Session["cart"] = list;
            }
            else
            {
                var item = new ChiTietDatHang();
                item.MaSanPham = id;
                item.SoLuong = quantity;
                var list = new List<ChiTietDatHang>();
                list.Add(item);

                // Gán vào session
                Session["cart"] = list;
            }
            return RedirectToAction("shopping");
            //var Cart = Session[SessionCart];
            //List<CartItem> ListCart = new List<CartItem>();
            //if (Cart != null)
            //    ListCart = (List<CartItem>)Cart;
            //if (ListCart.Any(a => a.Product.ID == ProductID))
            //{
            //    ListCart.Single(a => a.Product.ID == ProductID).Quantity++;
            //}
            //else
            //{
            //    ListCart.Add(new CartItem() { Product = new ProductDao().GetById(ProductID), Quantity = Quantity });
            //}

            //Session[SessionCart] = ListCart;

            //return RedirectToAction("Index");
        }
    }
}