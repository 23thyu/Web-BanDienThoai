using QLCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCoffee.Controllers
{
    public class NCCController : Controller
    {
        // GET: NCC
        QuanLyQuanCoffeeEntities database = new QuanLyQuanCoffeeEntities();
        public ActionResult Index()
        {
            return View(database.NHACUNGCAPs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHACUNGCAP nhacungcap)
        {
            database.NHACUNGCAPs.Add(nhacungcap);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            return View(database.NHACUNGCAPs.Where(s => s.MaNCC == id).FirstOrDefault());
        }
        public ActionResult Edit(string id)
        {
            return View(database.NHACUNGCAPs.Where(s => s.MaNCC == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, NHACUNGCAP nhacungcap)
        {
            database.Entry(nhacungcap).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            return View(database.NHACUNGCAPs.Where(s => s.MaNCC == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(string id, NHACUNGCAP nhacungcap)
        {
            nhacungcap = database.NHACUNGCAPs.Where(s => s.MaNCC == id).FirstOrDefault();
            database.NHACUNGCAPs.Remove(nhacungcap);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}