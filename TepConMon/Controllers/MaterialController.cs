using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepConMon.Models;

namespace TepConMon.Controllers
{
    public class MaterialController : Controller
    {
        OrderContext db = new OrderContext();
        // GET: Material
        public ActionResult Index()
        {
            return View(db.Materials.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Material material)
        {
            if(ModelState.IsValid)
            {
                db.Materials.Add(material);
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
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Material material = db.Materials.Find(id);
            if(material == null)
            {
                return HttpNotFound();
            }

            return View(material);
        }

        [HttpPost]
        public ActionResult Edit(Material material)
        {
            db.Entry(material).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Material material = db.Materials.Find(id);
            if(material != null)
            {
                db.Materials.Remove(material);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}