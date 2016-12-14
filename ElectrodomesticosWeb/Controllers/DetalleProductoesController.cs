using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectrodomesticosWeb.DAL;
using ElectrodomesticosWeb.Models;
using System.Diagnostics;

namespace ElectrodomesticosWeb.Controllers
{
    public class DetalleProductoesController : Controller
    {
        private ElectrodomesticosWebContext db = new ElectrodomesticosWebContext();

        // GET: DetalleProductoes
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var detalleProductos = db.DetalleProductos.Include(d => d.Producto);
            return View(detalleProductos.ToList());
        }

        // GET: DetalleProductoes/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProducto detalleProducto = db.DetalleProductos.Find(id);
            if (detalleProducto == null)
            {
                return HttpNotFound();
            }
            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre");
            return View();
        }

        // POST: DetalleProductoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Color,marca,cantidad,precio,ProductoId")] DetalleProducto detalleProducto ,HttpPostedFileBase upload)
        {


            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    string pic = System.IO.Path.GetFileName(upload.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Imagenes"), pic);
                    upload.SaveAs(path);



                    var photo = new Imagen
                    {
                        ImageName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Photo
                    };

                    detalleProducto.Imagen = photo;
                    

                }
                

                db.DetalleProductos.Add(detalleProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre", detalleProducto.ProductoId);
            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProducto detalleProducto = db.DetalleProductos.Find(id);
            if (detalleProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre",detalleProducto.ProductoId);
            return View(detalleProducto);
        }

        // POST: DetalleProductoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Color,marca,cantidad,precio,ImagenId,Imagen,ProductoId")] DetalleProducto detalleProducto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                /*if (upload != null && upload.ContentLength > 0)
                {

                    string pic = System.IO.Path.GetFileName(upload.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Imagenes"), pic);
                    upload.SaveAs(path);



                    var photo = new Imagen
                    {
                        ImageName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Photo
                    };
                   

                    detalleProducto.Imagen = photo;






                }
                */
                

                db.Entry(detalleProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre", detalleProducto.ProductoId);
            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProducto detalleProducto = db.DetalleProductos.Find(id);
            if (detalleProducto == null)
            {
                return HttpNotFound();
            }
            return View(detalleProducto);
        }

        // POST: DetalleProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleProducto detalleProducto = db.DetalleProductos.Find(id);
            db.DetalleProductos.Remove(detalleProducto);
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
