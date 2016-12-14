using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectrodomesticosWeb.DAL;
using ElectrodomesticosWeb.Models;

namespace ElectrodomesticosWeb.Controllers
{
    public class ComprasController : Controller
    {
        private ElectrodomesticosWebContext db = new ElectrodomesticosWebContext();
        public List<DetalleCompra> listaCompras;
        private bool encontrado;

        // GET: Compras
        public ActionResult Index()
        {
            return View(db.Compras.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create(int id)
        {
            Debug.WriteLine("Create");
            foreach (DetalleProducto dp in db.DetalleProductos.ToList())
            {
                if (dp.Id == id)
                {
                    Debug.WriteLine("Llego");
                    if (Session["DetalleProductos"] == null)
                    {
                        Debug.WriteLine("No hay datos, hacer nuevo");
                        DetalleCompra dc = new DetalleCompra();
                        dc.DetalleProducto = dp;
                        dc.DetalleProductoId = id;
                        dc.Cantidad = 1;
                        dc.TotalCompra = dc.Cantidad * dp.precio;
                        listaCompras = new List<DetalleCompra>();
                        
                        listaCompras.Add(dc);
                        Session["DetalleProductos"] = listaCompras;
                        Debug.WriteLine(listaCompras.Count);
                        break;
                    }
                    else
                    {
                        listaCompras = (List<DetalleCompra>)Session["DetalleProductos"];
                        foreach (DetalleCompra dCompra in listaCompras)
                        {
                            Debug.WriteLine("comparar: " + dCompra.DetalleProducto.Id + " : " + dp.Id);
                            if (dCompra.DetalleProducto.Id == dp.Id)
                            {
                                encontrado = true;
                                dCompra.Cantidad += 1;
                                dCompra.TotalCompra = dCompra.Cantidad * dCompra.DetalleProducto.precio;
                                Debug.WriteLine("Añadir cantidad");
                                Session["DetalleProductos"] = listaCompras;
                                break;
                            }
                        }
                        if (encontrado == false)
                        {
                            Debug.WriteLine("Añadir otro detalle compra");
                            DetalleCompra dc = new DetalleCompra();
                            dc.DetalleProducto = dp;
                            dc.DetalleProductoId = id;
                            dc.Cantidad = 1;
                            dc.TotalCompra = dc.Cantidad * dp.precio;
                            listaCompras.Add(dc);
                            Session["DetalleProductos"] = listaCompras;
                        }
                    }
                }
            }
            return View(listaCompras.ToList());
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCliente,NumTarjeta,Direccion,Telefono")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                List<DetalleCompra> listaDetalle = (List<DetalleCompra>)Session["DetalleProductos"];
                db.Compras.Add(compra);
                db.SaveChanges();

                Debug.WriteLine("id Compra ultimo: " + compra.Id);
                foreach (DetalleCompra dc in listaDetalle) {
                    dc.CompraId = compra.Id;
                    dc.Compra = compra;
                    Debug.WriteLine("Detalla compra cantidad: " + dc.Cantidad);
                    db.DetalleCompras.Add(dc);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCliente,NumTarjeta,Direccion,Telefono")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
