using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDenemeCRUD.Models.Entity;

namespace MvcDenemeCRUD.Controllers
{
    public class HomeController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            ViewBag.kategoriSayisi = db.tbl_kategoriler.Count();
            ViewBag.urunSayisi = db.tbl_urunler.Count();
            ViewBag.musteriSayisi = db.tbl_musteriler.Count();
            ViewBag.toplamSatis = db.tbl_satislar.Count();
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