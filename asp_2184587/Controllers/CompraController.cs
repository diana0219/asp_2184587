using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_2184587.Models;

namespace asp_2184587.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            using (var db = new inventarioEntities1())

                return View(db.compra.ToList());
        }

        public static string NombreUsuario(int? idUsuario)
        {
            using (var db = new inventarioEntities1())
            {
                return db.usuario.Find(idUsuario).nombre;
            }

        }
        public ActionResult ListarUsuario()
        {
            using (var db = new inventarioEntities1())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public ActionResult ListarCliente()
        {
            using (var db = new inventarioEntities1())
            {
                return PartialView(db.cliente.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(compra compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioEntities1())
                {
                    db.compra.Add(compra);
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
                var findUser = db.compra.Find(id);
                return View(findUser);
            }
        }




       
        public ActionResult Edit(int id)
        {

            using (var db = new inventarioEntities1())
            {
                compra compraEdit = db.compra.Where(a => a.id == id).FirstOrDefault();

                return View(compraEdit);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(compra compraEdit)
        {
            try
            {
                using (var db = new inventarioEntities1())
                {
                    var oldProduct = db.compra.Find(compraEdit.id);
                    oldProduct.fecha = compraEdit.fecha;
                    oldProduct.total = compraEdit.total;
                    oldProduct.id_usuario= compraEdit.id_usuario;
                    oldProduct.id_cliente= compraEdit.id_cliente;
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
                    var findUser = db.compra.Find(id);
                    db.compra.Remove(findUser);
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

