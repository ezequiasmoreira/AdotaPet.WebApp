﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdotaPet.WebApp.Models;
using AdotaPet.WebApp.Models.Entities;

namespace AdotaPet.WebApp.Controllers
{
    public class RecebimentoDoacoesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: RecebimentoDoacoes
        public ActionResult Index()
        {
            return View(db.RecebimentoDoacoes.ToList());
        }

        // GET: RecebimentoDoacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecebimentoDoacoes recebimentoDoacoes = db.RecebimentoDoacoes.Find(id);
            if (recebimentoDoacoes == null)
            {
                return HttpNotFound();
            }
            return View(recebimentoDoacoes);
        }

        // GET: RecebimentoDoacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecebimentoDoacoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Data_recebimento,Item")] RecebimentoDoacoes recebimentoDoacoes)
        {
            if (!ModelState.IsValid)
            {

                    recebimentoDoacoes.Ong_Id = db.Ong.Find(1);
                    db.RecebimentoDoacoes.Add(recebimentoDoacoes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
           
                
            }

            return View(recebimentoDoacoes);
        }

        // GET: RecebimentoDoacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecebimentoDoacoes recebimentoDoacoes = db.RecebimentoDoacoes.Find(id);
            if (recebimentoDoacoes == null)
            {
                return HttpNotFound();
            }
            return View(recebimentoDoacoes);
        }

        // POST: RecebimentoDoacoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Data_recebimento,Item")] RecebimentoDoacoes recebimentoDoacoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recebimentoDoacoes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recebimentoDoacoes);
        }

        // GET: RecebimentoDoacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecebimentoDoacoes recebimentoDoacoes = db.RecebimentoDoacoes.Find(id);
            if (recebimentoDoacoes == null)
            {
                return HttpNotFound();
            }
            return View(recebimentoDoacoes);
        }

        // POST: RecebimentoDoacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecebimentoDoacoes recebimentoDoacoes = db.RecebimentoDoacoes.Find(id);
            db.RecebimentoDoacoes.Remove(recebimentoDoacoes);
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
