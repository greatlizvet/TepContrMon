using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepConMon.Models;

namespace TepConMon.Controllers
{
    public class ZakazchikController : Controller
    {
        OrderContext db = new OrderContext();
        // GET: Zakazchik
        public ActionResult Index()
        {
            return View(db.Zakazchiks.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Zakazchik zakazchik)
        {
            if(ModelState.IsValid)
            {
                db.Zakazchiks.Add(zakazchik);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Zakazchik zakazchik = db.Zakazchiks.Find(id);
            if(zakazchik == null)
            {
                return HttpNotFound();
            }

            return View(zakazchik);
        }
    }
}