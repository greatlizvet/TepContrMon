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
    }
}