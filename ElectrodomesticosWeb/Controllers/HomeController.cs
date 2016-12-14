using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectrodomesticosWeb.DAL;
using ElectrodomesticosWeb.Models;


namespace ElectrodomesticosWeb.Controllers
{
    public class HomeController : Controller
    {
        private ElectrodomesticosWebContext db = new ElectrodomesticosWebContext();
        public ActionResult Index()
        {
            Console.WriteLine("HOLA HOME");
            var DetalleProductos = db.DetalleProductos.ToList();
            List<DetalleProducto> existentes = new List<DetalleProducto>();
            foreach(DetalleProducto dp in DetalleProductos)
            {
                if(dp.cantidad >0)
                {
                    existentes.Add(dp);
                }
            }
            return View(existentes.ToList());
            
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