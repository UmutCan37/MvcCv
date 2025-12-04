using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var values = repo.Find(x => x.ID == id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var values = repo.Find(x => x.ID == id);
            return View(values);
        }
        public ActionResult EgitimDuzenle(TblEgitimlerim p)
        {
            var values = repo.Find(x => x.ID == p.ID);
            values.AltBaslik1 = p.AltBaslik1;
            values.AltBaslik2 = p.AltBaslik2;
            values.Baslik = p.Baslik;
            values.GNO = p.GNO;
            values.Tarih = p.Tarih;
            repo.TUpdate(values);
            return RedirectToAction("Index");

        }
    }
}