using QLCoffee.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCoffee.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QuanLyQuanCoffeeEntities database = new QuanLyQuanCoffeeEntities();
        public ActionResult Index()
        {
            return View(database.SANPHAMs.ToList());
        }
        public ActionResult Create()
        {
            var sanpham = new SANPHAM

            {
                NgaySX = DateTime.Now
            };
            return View(sanpham);
        }
        [HttpPost]

        public ActionResult Create(SANPHAM sanpham, HttpPostedFileBase Image)
        {
            database.SANPHAMs.Add(sanpham);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            return View(database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault());
        }
        public ActionResult Edit(string id)
        {

            return View(database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, SANPHAM sanpham)
        {
            database.Entry(sanpham).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            return View(database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(string id, SANPHAM sanpham)
        {
            sanpham = database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault();
            database.SANPHAMs.Remove(sanpham);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Upload_Image(string idSanPham)
        {
            ViewBag.idSanPham = idSanPham;
            return View();
        }
       [HttpPost]
        public ActionResult Upload_Image( string idSanPham ,HttpPostedFileBase fileImage)
        {
            //1. Kiểm Tra hình
            if(fileImage == null)//If file trong sẽ hiện lỗi
            {
                ViewBag.error = "File empty";
                ViewBag.idSanPham = idSanPham;
                return View();

            }
            if(fileImage.ContentLength == 0)//file nó không có nội dung hoặc k có giá trị thì nó cũng báo lỗi

            {
                ViewBag.error = "File không có giá trị";
                ViewBag.idSanPham = idSanPham;
                return View();
            }

            //3. Xác định đường dẫn lưu file ; url tương đối => tuyệt đối
            var urlTuongDoi = "/Data/Image/";
            var urlTuyetDoi = Server.MapPath(urlTuongDoi);

            //4.Lưu File ( Chưa ktra trùng file)
            fileImage.SaveAs(urlTuyetDoi + fileImage.FileName);
            //5.Lưu vào data
            mapSanPham map = new mapSanPham();
            
            map.Upload_Image(idSanPham,urlTuongDoi+fileImage.FileName);
            ViewBag.idSanPham = idSanPham;
            return RedirectToAction("Index");
            
        }
    }
}