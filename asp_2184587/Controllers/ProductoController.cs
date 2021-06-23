using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_2184587.Models;
using Rotativa;
using System.IO;

namespace asp_2184587.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new inventarioEntities1())

                return View(db.producto.ToList());
        }

        public static string NombreProveedor(int? idProveedor)
        {
            using (var db = new inventarioEntities1())
            {
                return db.proveedor.Find(idProveedor).nombre;
            }

        }
        public ActionResult ListarProveedores()
        {
            using (var db = new inventarioEntities1())
            {
                return PartialView(db.proveedor.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto producto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioEntities1())
                {

                    db.producto.Add(producto);
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


        //public ActionResult Create(producto producto, /*HttpPostedFileBase IMAGEN*/)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    string filePath = string.Empty;
        //    if (IMAGEN != null)
        //    {
        //        string path = Server.MapPath("~/Uploads/");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        filePath = path + Path.GetFileName(IMAGEN.FileName);
        //        string extension = Path.GetExtension(IMAGEN.FileName);
        //        IMAGEN.SaveAs(filePath);

        //    }

        //    try
        //    {
        //        using (var db = new inventarioEntities1())
        //        {
        //            producto.IMAGEN = "/Uploads/" + Path.GetFileName(IMAGEN.FileName);
        //            db.producto.Add(producto);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", "error" + ex);
        //        return View();
        //    }
        //}
        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities1())
            {
                var findUser = db.producto.Find(id);
                return View(findUser);
            }
        }





        public ActionResult Edit(int id)
        {

            using (var db = new inventarioEntities1())
            {
                producto productoEdit = db.producto.Where(a => a.id == id).FirstOrDefault();

                return View(productoEdit);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(producto productoEdit)
        {
            try
            {
                using (var db = new inventarioEntities1())
                {
                    var oldProduct = db.producto.Find(productoEdit.id);
                    oldProduct.nombre = productoEdit.nombre;
                    oldProduct.precio_unitario = productoEdit.precio_unitario;
                    oldProduct.descripcion = productoEdit.descripcion;
                    oldProduct.cantidad = productoEdit.cantidad;
                    oldProduct.id_proveedor = productoEdit.id_proveedor;
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
                    var findUser = db.producto.Find(id);
                    db.producto.Remove(findUser);
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

        public ActionResult Reporte()

        {
            var db = new inventarioEntities1();

            var query = from tabProvedor in db.proveedor
                        join tabProducto in db.producto on tabProvedor.id equals tabProducto.id_proveedor
                        select new Reporte
                        {
                            nombreProvedor = tabProvedor.nombre,
                            telefonoProvedor = tabProvedor.telefono,
                            direccionProvedor = tabProvedor.direccion,
                            nombreProducto = tabProducto.nombre,
                            precioProducto = tabProducto.precio_unitario,

                        };
            return View(query);


        }

        public ActionResult ImprimirReporte()
        {

            return new ActionAsPdf("Reporte") { FileName = "Reporte.pdf" };

        }
        


        

    }
}

