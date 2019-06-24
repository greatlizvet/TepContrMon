using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepConMon.Models;

namespace TepConMon.Controllers
{
    public class WorkController : Controller
    {
        OrderContext db = new OrderContext();
        // GET: Work
        public ActionResult Index()
        {
            return View(db.Works.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Workers = db.Workers.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Work work, int[] selWorkers)
        {
            if(ModelState.IsValid)
            {
                if(selWorkers != null)
                {
                    foreach(var w in db.Workers.Where(wo => selWorkers.Contains(wo.Id)))
                    {
                        work.Workers.Add(w);
                    }
                }
                db.Works.Add(work);
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
            Work work = db.Works.Find(id);
            if(work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }
    }
}