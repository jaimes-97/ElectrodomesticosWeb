using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectrodomesticosWeb.DAL;


namespace ElectrodomesticosWeb.Controllers
{
    public class HomeController : Controller
    {
        private ElectrodomesticosWebContext db = new ElectrodomesticosWebContext();
        public ActionResult Index()
        {
            Console.WriteLine("HOLA HOME");
            var DetalleProductos = db.DetalleProductos;
            return View(DetalleProductos.ToList());
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}