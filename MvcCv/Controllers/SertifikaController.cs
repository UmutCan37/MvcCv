using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TblSetifakalarım> repo = new GenericRepository<TblSetifakalarım>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSetifakalarım p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var values = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(values);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSetifakalarım p)
        {
            var values = repo.Find(x => x.ID == p.ID);
            values.Acıklama = p.Acıklama;
            values.Tarih = p.Tarih;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var values=repo.Find(x => x.ID == id);
            repo.TDelete(values);
            return RedirectToAction("Index");

        }
    }
}