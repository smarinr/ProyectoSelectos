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
    public class ArticuloPerdidoesController : Controller
    {
        private ProyectoArticuloPerdidoEntities db = new ProyectoArticuloPerdidoEntities();

        // GET: ArticuloPerdidoes
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var usuarios = from s in db.ArticuloPerdido
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                usuarios = usuarios.Where(s => s.descripcionArticuloPerdido.Contains(searchString)
                                       || s.statusArticuloPerdido.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "descripcionArticuloPerdido ":
                    usuarios = usuarios.OrderByDescending(s => s.descripcionArticuloPerdido);
                    break;
                case "statusArticuloPerdido":
                    usuarios = usuarios.OrderBy(s => s.statusArticuloPerdido);
                    break;
                default:
                    usuarios = usuarios.OrderBy(s => s.descripcionArticuloPerdido);
                    break;
            }

            return View(usuarios.ToList());

           // var articuloPerdido = db.ArticuloPerdido.Include(a => a.Categoria);
           // return View(articuloPerdido.ToList());
        }

        // GET: ArticuloPerdidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloPerdido articuloPerdido = db.ArticuloPerdido.Find(id);
            if (articuloPerdido == null)
            {
                return HttpNotFound();
            }
            return View(articuloPerdido);
        }

        // GET: ArticuloPerdidoes/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nombreCategoria");
            return View();
        }

        // POST: ArticuloPerdidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArticuloPerdido,descripcionArticuloPerdido,statusArticuloPerdido,idCategoria")] ArticuloPerdido articuloPerdido)
        {
            if (ModelState.IsValid)
            {
                db.ArticuloPerdido.Add(articuloPerdido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nombreCategoria", articuloPerdido.idCategoria);
            return View(articuloPerdido);
        }

        // GET: ArticuloPerdidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloPerdido articuloPerdido = db.ArticuloPerdido.Find(id);
            if (articuloPerdido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nombreCategoria", articuloPerdido.idCategoria);
            return View(articuloPerdido);
        }

        // POST: ArticuloPerdidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArticuloPerdido,descripcionArticuloPerdido,statusArticuloPerdido,idCategoria")] ArticuloPerdido articuloPerdido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articuloPerdido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nombreCategoria", articuloPerdido.idCategoria);
            return View(articuloPerdido);
        }

        // GET: ArticuloPerdidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloPerdido articuloPerdido = db.ArticuloPerdido.Find(id);
            if (articuloPerdido == null)
            {
                return HttpNotFound();
            }
            return View(articuloPerdido);
        }

        // POST: ArticuloPerdidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticuloPerdido articuloPerdido = db.ArticuloPerdido.Find(id);
            db.ArticuloPerdido.Remove(articuloPerdido);
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
