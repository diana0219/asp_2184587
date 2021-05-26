using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_2184587.Models;

namespace asp_2184587.Controllers
{
    public class Producto_CompraController : Controller
    {
        // GET: Producto_Compra
        public ActionResult Index()
        {
            using (var db = new inventarioEntities1())

                return View(db.producto_compra.ToList());
        }

        public static string NombreProducto(int? idProducto)
        {
            using (var db = new inventarioEntities1())
            {
                return db.producto.Find(idProducto).nombre;
            }

        }
        public ActionResult ListarProducto()
        {
            using (var db = new inventarioEntities1())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult ListarCompra()
		{
            using (var db = new inventarioEntities1())
			{
                return PartialView(db.compra.ToList());
			}
		}

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto_compra producto_compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioEntities1())
                {
                    db.producto_compra.Add(producto_compra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities1())
            {
                var findUser = db.producto_compra.Find(id);
                return View(findUser);
            }
        }





        public ActionResult Edit(int id)
        {

            using (var db = new inventarioEntities1())
            {
                producto_compra producto_compraEdit = db.producto_compra.Where(a => a.id == id).FirstOrDefault();

                return View(producto_compraEdit);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(producto_compra producto_compraEdit)
        {
            try
            {
                using (var db = new inventarioEntities1())
                {
                    var oldProduct = db.producto_compra.Find(producto_compraEdit.id);
                    oldProduct.cantidad = producto_compraEdit.cantidad;
                    oldProduct.id_compra = producto_compraEdit.id_compra;
                    oldProduct.id_producto = producto_compraEdit.id_producto;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventarioEntities1())
                {
                    var findUser = db.producto_compra.Find(id);
                    db.producto_compra.Remove(findUser);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

    }

}