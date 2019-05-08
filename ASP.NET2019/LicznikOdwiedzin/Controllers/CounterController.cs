using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicznikOdwiedzin.Controllers
{
    public class CounterController : Controller
    {
        private volatile static int counter = 0;
        private static String mon = "MON"; 
        // GET: Counter
        public ActionResult Index()
        {
            lock (mon)
            {
                counter++;
                ViewBag.Counter = "" + counter;
            }
            return View();
        }
    }
}