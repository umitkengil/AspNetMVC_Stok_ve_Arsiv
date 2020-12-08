using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDenemeCRUD.Models.Entity;
namespace MvcDenemeCRUD.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar

        MvcDbStokEntities db = new MvcDbStokEntities();

        
        public ActionResult Satislar(int id)
        {
            var satisListele = db.tbl_satislar.Where(f=>f.statu== id).ToList();

            return View("Index",satisListele);
        }

        public ActionResult Arsivler(int url_parametre)
        {

            var guncelle = db.tbl_satislar.Find(url_parametre);

            guncelle.statu = 1;

            db.SaveChanges();

            return RedirectToAction("Satislar", "Satislar", new { id = 0 });
        }

        public ActionResult GeriAl(int id)
        {

            var guncelle = db.tbl_satislar.Find(id);

            guncelle.statu = 0;

            db.SaveChanges();

            return RedirectToAction("Satislar", "Satislar", new { id = 1 });
        }
        

        [HttpGet]
        public ActionResult YeniSatisEkle()
        {
            List<SelectListItem> satislar = (from deger in db.tbl_musteriler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = deger.musteri_ad + ' ' + deger.musteri_soyad,
                                                Value = deger.musteri_id.ToString()
                                            }).ToList();

            List<SelectListItem> urun = (from deger in db.tbl_urunler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = deger.urun_ad,
                                                 //Text = deger.urun_fiyat.ToString(),
                                                 Value = deger.urun_id.ToString()
                                             }).ToList();


            ViewBag.degerAl = satislar;
            ViewBag.degerAl_urunler = urun;
            return View();
        }

        [HttpPost]

        public ActionResult YeniSatisEkle(tbl_satislar p1)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("YeniSatisEkle");
            //}
            var urunler = db.tbl_urunler.Where(m => m.urun_id == p1.tbl_urunler.urun_id).FirstOrDefault();
            p1.tbl_urunler = urunler;

            var musteri = db.tbl_musteriler.Where(m => m.musteri_id == p1.tbl_musteriler.musteri_id).FirstOrDefault();
            p1.tbl_musteriler = musteri;

            db.tbl_satislar.Add(p1);
            db.SaveChanges();
            return  RedirectToAction("Satislar", "Satislar",new { id=0 });
        }

        public ActionResult SatisGetir(int id)
        {
            var satisGetir = db.tbl_satislar.Find(id);

            List<SelectListItem> urunGetir = (from deger in db.tbl_urunler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = deger.urun_ad,
                                                  Value = deger.urun_id.ToString()
                                              }).ToList();

            List<SelectListItem> musteriGetir = (from deger in db.tbl_musteriler.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = deger.musteri_ad + ' ' + deger.musteri_soyad,
                                                     Value = deger.musteri_id.ToString()
                                                 }).ToList();

            ViewBag.degerAl = urunGetir;
            ViewBag.degerAl_musteri = musteriGetir;

            return View("SatisGetir",satisGetir);
        }

        [HttpPost]
        public ActionResult Guncelle(tbl_satislar p1)
        {

            var guncelle = db.tbl_satislar.Find(p1.satis_id);

            guncelle.urun = p1.tbl_urunler.urun_id;
            guncelle.musteri = p1.tbl_musteriler.musteri_id;
            guncelle.adet = p1.adet;
            guncelle.fiyati = p1.fiyati;

            db.SaveChanges();

            return RedirectToAction("Satislar", "Satislar",new { id=0 });
        }
    }
}