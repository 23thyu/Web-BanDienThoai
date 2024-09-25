using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCoffee.Models
{
    public class mapSanPham
    {
        public bool Upload_Image(string idSanPham, string Image_url) 
        {
            try
            {
                QuanLyQuanCoffeeEntities db = new QuanLyQuanCoffeeEntities();
                var SanPham = db.SANPHAMs.Find(idSanPham);
                SanPham.Image1 = Image_url;
                db.SaveChanges();
                return true;
            }
            catch 
            { 
                return false; 
            }

        }
    }
}