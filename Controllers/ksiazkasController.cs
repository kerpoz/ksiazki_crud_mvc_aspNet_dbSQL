using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ksiazki_crud.Models;

namespace ksiazki_crud.Controllers
{
    public class ksiazkasController : Controller
    {
        private KsiazkiEntities1 db = new KsiazkiEntities1();

        // GET: ksiazkas
        public ActionResult Index()
        {
            return View(db.ksiazkas.ToList());
        }

        // GET: ksiazkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ksiazka ksiazka = db.ksiazkas.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // GET: ksiazkas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ksiazkas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,tytul,autor,cena")] ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.ksiazkas.Add(ksiazka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ksiazka);
        }

        // GET: ksiazkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ksiazka ksiazka = db.ksiazkas.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // POST: ksiazkas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,tytul,autor,cena")] ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiazka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ksiazka);
        }

        // GET: ksiazkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ksiazka ksiazka = db.ksiazkas.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // POST: ksiazkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ksiazka ksiazka = db.ksiazkas.Find(id);
            db.ksiazkas.Remove(ksiazka);
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
