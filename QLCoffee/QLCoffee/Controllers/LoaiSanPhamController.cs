using QLCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCoffee.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        QuanLyQuanCoffeeEntities database = new QuanLyQuanCoffeeEntities();
        public ActionResult Index()
        {
            return View(database.LOAISANPHAMs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LOAISANPHAM loaisanpham)
        {
            database.LOAISANPHAMs.Add(loaisanpham);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            return View(database.LOAISANPHAMs.Where(s => s.MaLoaiSP == id).FirstOrDefault());
        }
        public ActionResult Edit(string id)
        {
            return View(database.LOAISANPHAMs.Where(s => s.MaLoaiSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, LOAISANPHAM loaisanpham)
        {
            database.Entry(loaisanpham).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            return View(database.LOAISANPHAMs.Where(s => s.MaLoaiSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(string id, LOAISANPHAM loaisanpham)
        {
            loaisanpham = database.LOAISANPHAMs.Where(s => s.MaLoaiSP == id).FirstOrDefault();
            database.LOAISANPHAMs.Remove(loaisanpham);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}