using QLCoffee.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCoffee.Areas.Admin.Controllers
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
            ViewBag.IDPro = new SelectList(database.PRODUCTs, "IDPro", "NamePro");
            ViewBag.MaMau = new SelectList(database.MAUs, "MaMau", "TenMau", sanpham.MaMau);
            return View(sanpham);
        }
        [HttpPost]

        public ActionResult Create(SANPHAM sanpham)
        {
            ViewBag.IDPro = new SelectList(database.PRODUCTs, "IDPro", "NamePro", sanpham.IDPro);
            ViewBag.MaMau = new SelectList(database.MAUs, "MaMau", "TenMau", sanpham.MaMau);
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
            var sanpham = new SANPHAM
            {
                NgaySX = DateTime.Now
            };
            ViewBag.IsEdit = true;
            ViewBag.IDPro = new SelectList(database.PRODUCTs, "IDPro", "NamePro");
            ViewBag.MaMau = new SelectList(database.MAUs, "MaMau", "TenMau");
            return View(database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, SANPHAM sanpham)
        {
            if (ModelState.IsValid)
            {
                database.Entry(sanpham).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }
                
            ViewBag.IDPro = new SelectList(database.PRODUCTs, "IDPro", "NamePro", sanpham.IDPro);
            ViewBag.MaMau = new SelectList(database.MAUs, "MaMau", "TenMau", sanpham.MaMau);
            return View(sanpham);
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
        public ActionResult Update_Image(string idSanPham)
        {
            ViewBag.idSanPham = idSanPham;
            return View();

        }
        [HttpPost]
        public ActionResult Update_Image(string idSanPham, HttpPostedFileBase fileImage, SANPHAM sanpham)
        {
            sanpham = database.SANPHAMs.Where(s => s.MaSP == idSanPham).FirstOrDefault();
            if (fileImage == null) //nếu để trống thì báo lỗi
            {
                ViewBag.error = "File empty";
                ViewBag.idSanPham = idSanPham;
                return View();

            }
            if (fileImage.ContentLength == 0)//nếu thêm dữ liệu nhưng đó không có nội dung thì báo lỗi
            {
                ViewBag.error = "Don't have topic";
                ViewBag.idSanpham = idSanPham;
                return View();
            }
            //Xác định đường dẫn lưu file : Url tương đối => tuyệt đối 
            var urlTuongDoi = "/Data/Image/";
            var urlTuyetDoi = Server.MapPath(urlTuongDoi);
            //Lưu file (Chưa check same file)
            fileImage.SaveAs(urlTuyetDoi + fileImage.FileName);

            string fullDuongDan = urlTuyetDoi + fileImage.FileName;
            int i = 1;
            while (System.IO.File.Exists(fullDuongDan) == true)
            {
                string ten = Path.GetFileNameWithoutExtension(fullDuongDan);
                string duoi = Path.GetExtension(fileImage.FileName);
                fullDuongDan = urlTuyetDoi + ten + "-" + i + duoi;
                i++;
            }
            fileImage.SaveAs(fullDuongDan);

            mapSanPham map = new mapSanPham();
            map.UpdateImage(idSanPham, urlTuongDoi + fileImage.FileName);


            ViewBag.idSanPham = idSanPham;
            return RedirectToAction("Index");

        }

    }
}