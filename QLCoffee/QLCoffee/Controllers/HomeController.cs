using QLCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCoffee.Controllers
{
    public class HomeController : Controller
    {
        QuanLyQuanCoffeeEntities db = new QuanLyQuanCoffeeEntities();
        
        public ActionResult DanhSachSanPham()
        {
            var listSP = db.SANPHAMs.ToList();

            return View(listSP);
        }
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}