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
    }
}