using QLCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCoffee.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        QuanLyQuanCoffeeEntities database = new QuanLyQuanCoffeeEntities();
        public ActionResult Index()
        {
            return View(database.TAIKHOANs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TAIKHOAN taikhoan)
        {
            database.TAIKHOANs.Add(taikhoan);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            return View(database.TAIKHOANs.Where(s => s.TenDN == id).FirstOrDefault());
        }
        public ActionResult Edit(string id)
        {
            return View(database.TAIKHOANs.Where(s => s.TenDN == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, TAIKHOAN taikhoan)
        {
            database.Entry(taikhoan).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            return View(database.TAIKHOANs.Where(s => s.TenDN == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(string id, TAIKHOAN taikhoan)
        {
            taikhoan = database.TAIKHOANs.Where(s => s.TenDN == id).FirstOrDefault();
            database.TAIKHOANs.Remove(taikhoan);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}