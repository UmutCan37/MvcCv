using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var value = repo.Find(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p)
        {
            var value = repo.Find(x => x.ID ==p.ID);
            value.Durum = p.Durum;
            value.ikon = p.ikon;
            value.Ad = p.Ad;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
        
            public ActionResult Sil(int id)
        {
            var value = repo.Find(x => x.ID == id);
            value.Durum = false;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}