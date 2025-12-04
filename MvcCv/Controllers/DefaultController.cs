using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        // GET: Default
        public ActionResult Index()
        {
            var values = db.TblHakkimda.ToList();
            return View(values);
        }
        public PartialViewResult SosyalMedya()
        {
            var values = db.TblSosyalMedya.ToList();
            return PartialView(values);
        }
        public PartialViewResult Deneyim()
        {
            var values = db.TblDeneyim.ToList();
            return PartialView(values);
        }
        public PartialViewResult Egitim()
        {
            var values = db.TblEgitimlerim.ToList();
            return PartialView(values);
        }
        public PartialViewResult Yetenek()
        {
            var values = db.TblYeteneklerim.ToList();
            return PartialView(values);
        }
        public PartialViewResult Hobi()
        {
            var values = db.TblHobilerim.ToList();
            return PartialView(values);
        }
        
        public PartialViewResult Sertifika()
        {
            var values = db.TblSetifakalarım.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim p)
        {
            p.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}