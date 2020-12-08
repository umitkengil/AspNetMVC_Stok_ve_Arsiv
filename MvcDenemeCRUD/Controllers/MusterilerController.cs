using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDenemeCRUD.Models.Entity;

namespace MvcDenemeCRUD.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var musteri_list = db.tbl_musteriler.ToList();

            return View("Index",musteri_list);
        }

        public ActionResult YeniMusteriEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult YeniMusteriEkle(tbl_musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteriEkle");
            }

            db.tbl_musteriler.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteriGetir = db.tbl_musteriler.Find(id);

            return View("MusteriGetir",musteriGetir);
        }

        public ActionResult Guncelle(tbl_musteriler p1)
        {
            var guncelle = db.tbl_musteriler.Find(p1.musteri_id);

            guncelle.musteri_ad = p1.musteri_ad;
            guncelle.musteri_soyad = p1.musteri_soyad;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sil = db.tbl_musteriler.Find(id);

            db.tbl_musteriler.Remove(sil);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}