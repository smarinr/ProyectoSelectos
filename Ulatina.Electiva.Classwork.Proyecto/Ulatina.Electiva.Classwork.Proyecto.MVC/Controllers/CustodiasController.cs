using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ulatina.Electiva.Classwork.Proyecto.Model;

namespace Ulatina.Electiva.Classwork.Proyecto.MVC.Controllers
{
    public class CustodiasController : Controller
    {
        private ProyectoArticuloPerdidoEntities db = new ProyectoArticuloPerdidoEntities();

        // GET: Custodias
        public ActionResult Index(string sortOrder, string searchString)
        {
            var custodia = db.Custodia.Include(c => c.ArticuloPerdido).Include(c => c.Usuario).Include(c => c.Usuario1);

            ViewBag.UserSortParm = String.IsNullOrEmpty(sortOrder) ? "user_cust" : "";
            ViewBag.User1SortParm = String.IsNullOrEmpty(sortOrder) ? "user_report" : "";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date" : "";

            var custodias = from s in db.Custodia select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                custodia = custodia.Where(s => s.ArticuloPerdido.descripcionArticuloPerdido.Contains(searchString)
                                       || s.Usuario.nombreUsuario.Contains(searchString) || s.Usuario1.nombreUsuario.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "user_cust":
                    custodias = custodias.OrderByDescending(s => s.Usuario.nombreUsuario);
                    break;
                case "user_report":
                    custodias = custodias.OrderBy(s => s.Usuario1.nombreUsuario);
                    break;
                case "date":
                    custodias = custodias.OrderByDescending(s => s.fechaCustodiaIngresada);
                    break;
                default:
                    custodias = custodias.OrderBy(s => s.Usuario.nombreUsuario);
                    break;
            }

            return View(custodias.ToList());

        }

        // GET: Custodias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custodia custodia = db.Custodia.Find(id);
            if (custodia == null)
            {
                return HttpNotFound();
            }
            return View(custodia);
        }

        // GET: Custodias/Create
        public ActionResult Create()
        {
            ViewBag.idArticuloPerdido = new SelectList(db.ArticuloPerdido, "idArticuloPerdido", "descripcionArticuloPerdido");
            ViewBag.idUsuarioCustodia = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioReporta = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Custodias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCustodia,idArticuloPerdido,idUsuarioReporta,idUsuarioCustodia,fechaCustodiaIngresada")] Custodia custodia)
        {
            if (ModelState.IsValid)
            {
                db.Custodia.Add(custodia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArticuloPerdido = new SelectList(db.ArticuloPerdido, "idArticuloPerdido", "descripcionArticuloPerdido", custodia.idArticuloPerdido);
            ViewBag.idUsuarioCustodia = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", custodia.idUsuarioCustodia);
            ViewBag.idUsuarioReporta = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", custodia.idUsuarioReporta);
            return View(custodia);
        }

        // GET: Custodias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custodia custodia = db.Custodia.Find(id);
            if (custodia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticuloPerdido = new SelectList(db.ArticuloPerdido, "idArticuloPerdido", "descripcionArticuloPerdido", custodia.idArticuloPerdido);
            ViewBag.idUsuarioCustodia = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", custodia.idUsuarioCustodia);
            ViewBag.idUsuarioReporta = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", custodia.idUsuarioReporta);
            return View(custodia);
        }

        // POST: Custodias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCustodia,idArticuloPerdido,idUsuarioReporta,idUsuarioCustodia,fechaCustodiaIngresada")] Custodia custodia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custodia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArticuloPerdido = new SelectList(db.ArticuloPerdido, "idArticuloPerdido", "descripcionArticuloPerdido", custodia.idArticuloPerdido);
            ViewBag.idUsuarioCustodia = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", custodia.idUsuarioCustodia);
            ViewBag.idUsuarioReporta = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", custodia.idUsuarioReporta);
            return View(custodia);
        }

        // GET: Custodias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custodia custodia = db.Custodia.Find(id);
            if (custodia == null)
            {
                return HttpNotFound();
            }
            return View(custodia);
        }

        // POST: Custodias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Custodia custodia = db.Custodia.Find(id);
            db.Custodia.Remove(custodia);
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
