using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDenemeCRUD.Models.Entity;

namespace MvcDenemeCRUD.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var urun_listele = db.tbl_urunler.ToList();
            
            return View("Index",urun_listele);
        }

        [HttpGet]
        public ActionResult YeniUrunEkle()
        {
            List<SelectListItem> kategoriler = (from deger in db.tbl_kategoriler.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = deger.kategori_ad,
                                                        Value = deger.kategori_id.ToString()
                                                    }).ToList();

            ViewBag.degerAl = kategoriler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniUrunEkle(tbl_urunler p1)
        {
            //Kullanıcının seçtiği kategori ile db'de ki kategori aynı mı
            var kategori = db.tbl_kategoriler.Where(m => m.kategori_id == p1.tbl_kategoriler.kategori_id).FirstOrDefault();

            p1.tbl_kategoriler = kategori;

            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urunGetir = db.tbl_urunler.Find(id);

            List<SelectListItem> degerler = (from deger in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = deger.kategori_ad,
                                                 Value = deger.kategori_id.ToString()
                                             }).ToList();

            ViewBag.degerAl = degerler;
            return View("UrunGetir",urunGetir);
        }

        public ActionResult Guncelle(tbl_urunler p1)
        {
            var guncelle = db.tbl_urunler.Find(p1.urun_id);

            guncelle.urun_ad = p1.urun_ad;
            guncelle.urun_fiyat = p1.urun_fiyat;
            //guncelle.urun_kategori = p1.urun_kategori;
            guncelle.urun_marka = p1.urun_marka;
            guncelle.urun_stok = p1.urun_stok;

            var ktg = db.tbl_kategoriler.Where(m => m.kategori_id == p1.tbl_kategoriler.kategori_id).FirstOrDefault();

            guncelle.urun_kategori = ktg.kategori_id;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.tbl_urunler.Find(id);

            db.tbl_urunler.Remove(urun);

            return RedirectToAction("Index");
        }
    }
}