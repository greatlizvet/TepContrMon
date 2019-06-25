using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TepConMon.Models;

namespace TepConMon.Controllers
{
    public class OrderController : Controller
    {
        OrderContext db = new OrderContext();
        // GET: Order
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList zakazchiki = new SelectList(db.Zakazchiks, "Id", "Name");
            ViewBag.Zakazhiki = zakazchiki;
            ViewBag.Works = db.Works.ToList();
            ViewBag.Materials = db.Materials.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order, int[] selWork, int[] selMat)
        {
            //добавляем работы для заказа
            if(selWork != null)
            {
                foreach(var w in db.Works.Where(wo => selWork.Contains(wo.Id)))
                {
                    order.Works.Add(w);
                }
            }
            //добавляем материалы для заказа
            if(selMat != null)
            {
                foreach(var m in db.Materials.Where(ma => selMat.Contains(ma.Id)))
                {
                    order.Materials.Add(m);
                }
            }

            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Order order = db.Orders.Find(id);
            if(order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Order order = db.Orders.Find(id);
            if(order == null)
            {
                return HttpNotFound();
            }
            SelectList zakazchiki = new SelectList(db.Zakazchiks, "Id", "Name");
            ViewBag.Zakazhiki = zakazchiki;
            ViewBag.Works = db.Works.ToList();
            ViewBag.Materials = db.Materials.ToList();

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order, int[] selWork, int[] selMat)
        {
            Order newOrder = db.Orders.Find(order.Id);
            newOrder.Number = order.Number;
            newOrder.ZakazchikId = order.ZakazchikId;

            newOrder.Materials.Clear();
            if (selMat != null)
            {
                foreach (var m in db.Materials.Where(ma => selMat.Contains(ma.Id)))
                {
                    newOrder.Materials.Add(m);
                }
            }

            newOrder.Works.Clear();
            if (selWork != null)
            {
                foreach (var w in db.Works.Where(wo => selWork.Contains(wo.Id)))
                {
                    newOrder.Works.Add(w);
                }
            }

            db.Entry(newOrder).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}