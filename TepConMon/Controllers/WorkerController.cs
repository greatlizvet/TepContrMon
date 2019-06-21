using System;
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
    }
}