using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCparcialJose.Models;

namespace MVCparcialJose.Controllers
{
    public class JoseMarioLamiFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: JoseMarioLamiFriends
        public ActionResult Index()
        {
            return View(db.JoseMarioLamiFriends.ToList());
        }

        // GET: JoseMarioLamiFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JoseMarioLamiFriend joseMarioLamiFriend = db.JoseMarioLamiFriends.Find(id);
            if (joseMarioLamiFriend == null)
            {
                return HttpNotFound();
            }
            return View(joseMarioLamiFriend);
        }

        // GET: JoseMarioLamiFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JoseMarioLamiFriends/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendId,Name,Nickname,Birthdate,Type")] JoseMarioLamiFriend joseMarioLamiFriend)
        {
            if (ModelState.IsValid)
            {
                db.JoseMarioLamiFriends.Add(joseMarioLamiFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(joseMarioLamiFriend);
        }

        // GET: JoseMarioLamiFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JoseMarioLamiFriend joseMarioLamiFriend = db.JoseMarioLamiFriends.Find(id);
            if (joseMarioLamiFriend == null)
            {
                return HttpNotFound();
            }
            return View(joseMarioLamiFriend);
        }

        // POST: JoseMarioLamiFriends/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendId,Name,Nickname,Birthdate,Type")] JoseMarioLamiFriend joseMarioLamiFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joseMarioLamiFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(joseMarioLamiFriend);
        }

        // GET: JoseMarioLamiFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JoseMarioLamiFriend joseMarioLamiFriend = db.JoseMarioLamiFriends.Find(id);
            if (joseMarioLamiFriend == null)
            {
                return HttpNotFound();
            }
            return View(joseMarioLamiFriend);
        }

        // POST: JoseMarioLamiFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JoseMarioLamiFriend joseMarioLamiFriend = db.JoseMarioLamiFriends.Find(id);
            db.JoseMarioLamiFriends.Remove(joseMarioLamiFriend);
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
