using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLCoffee.Models;

namespace QLCoffee.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        QuanLyQuanCoffeeEntities database = new QuanLyQuanCoffeeEntities();
        public ActionResult Index()
        {
            return View(database.NHANVIENs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHANVIEN nhanvien)
        {
            database.NHANVIENs.Add(nhanvien);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            return View(database.NHANVIENs.Where(s => s.MaNV == id).FirstOrDefault());
        }
        public ActionResult Edit(string id)
        {
            return View(database.NHANVIENs.Where(s => s.MaNV == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id,NHANVIEN nhanvien)
        {
            database.Entry(nhanvien).State=System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            return View(database.NHANVIENs.Where(s => s.MaNV == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(string id,NHANVIEN nhanvien)
        {
            nhanvien = database.NHANVIENs.Where(s => s.MaNV == id).FirstOrDefault();
            database.NHANVIENs.Remove(nhanvien);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}