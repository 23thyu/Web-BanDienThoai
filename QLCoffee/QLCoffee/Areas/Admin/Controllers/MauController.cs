using QLCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCoffee.Areas.Admin.Controllers
{
    public class MauController : Controller
    {
        // GET: Admin/Mau
        QuanLyQuanCoffeeEntities database = new QuanLyQuanCoffeeEntities();
        public ActionResult Index()
        {
            return View(database.MAUs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MAU mau)
        {
            database.MAUs.Add(mau);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(database.MAUs.Where(s => s.MaMau == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.MAUs.Where(s => s.MaMau == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, MAU mau)
        {
            database.Entry(mau).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.MAUs.Where(s => s.MaMau == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, MAU mau)
        {
            mau = database.MAUs.Where(s => s.MaMau == id).FirstOrDefault();
            database.MAUs.Remove(mau);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}