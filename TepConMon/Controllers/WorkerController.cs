﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepConMon.Models;

namespace TepConMon.Controllers
{
    public class WorkerController : Controller
    {
        OrderContext db = new OrderContext();
        // GET: Worker
        public ActionResult Index()
        {
            return View(db.Workers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Worker worker)
        {
            if(ModelState.IsValid)
            {
                db.Workers.Add(worker);
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
            Worker worker = db.Workers.Find(id);
            if(worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }

            return View(worker);
        }

        [HttpPost]
        public ActionResult Edit(Worker worker)
        {
            db.Entry(worker).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Worker worker = db.Workers.Find(id);
            if (worker != null)
            {
                db.Workers.Remove(worker);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}