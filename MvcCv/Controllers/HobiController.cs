using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        HobiRepository repo = new HobiRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]        
        public ActionResult Index(TblHobilerim p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Acıklama1 = p.Acıklama1;
            t.Acıklama2 = p.Acıklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}