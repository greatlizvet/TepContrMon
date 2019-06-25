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

        [HttpGet]
        public ActionResult Edit(int? id)
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

            ViewBag.Workers = db.Workers.ToList();
            return View(work);
        }

        [HttpPost]
        public ActionResult Edit(Work work, int[] selWorkers)
        {
            if(ModelState.IsValid)
            {
                Work newWork = db.Works.Find(work.Id);
                newWork.Name = work.Name;
                newWork.Description = work.Description;

                newWork.Workers.Clear();
                if (selWorkers != null)
                {
                    foreach (var w in db.Workers.Where(wo => selWorkers.Contains(wo.Id)))
                    {
                        newWork.Workers.Add(w);
                    }
                }
                db.Entry(newWork).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Work work = db.Works.Find(id);
            if (work != null)
            {
                db.Works.Remove(work);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}