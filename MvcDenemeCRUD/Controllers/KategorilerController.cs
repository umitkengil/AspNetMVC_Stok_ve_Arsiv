using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDenemeCRUD.Models.Entity;

namespace MvcDenemeCRUD.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var ktg_list = db.tbl_kategoriler.ToList();

            return View("Index",ktg_list);
        }

        public ActionResult YeniKategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategoriEkle(tbl_kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategoriEkle");
            }

            db.tbl_kategoriler.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.tbl_kategoriler.Find(id);

            return View("KategoriGetir",kategori);
        }

        public ActionResult Guncelle(tbl_kategoriler p1)
        {
            var guncelle = db.tbl_kategoriler.Find(p1.kategori_id);
            guncelle.kategori_ad = p1.kategori_ad;

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var kategori = db.tbl_kategoriler.Find(id);

            db.tbl_kategoriler.Remove(kategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}