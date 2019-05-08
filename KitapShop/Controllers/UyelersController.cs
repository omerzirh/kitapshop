using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KitapShop.Models;

namespace KitapShop.Controllers
{
    public class UyelersController : Controller
    {
        private KitapShopEntities db = new KitapShopEntities();

        // GET: Uyelers
        public ActionResult Index()
        {
            if (Session["Kid"] != null)
            {
                if (Session["Rol"].ToString() == "admin")
                   return View(db.Uyeler.ToList());
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
           
        }

        // GET: Uyelers/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Kid"] != null)
            {
                if (Session["Rol"].ToString() == "admin")
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Uyeler uyeler = db.Uyeler.Find(id);
                    if (uyeler == null)
                    {
                        return HttpNotFound();
                    }
                    return View(uyeler);
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
        }

        // GET: Uyelers/Create
        public ActionResult Create()
        {
            if (Session["Kid"] != null)
            {
                if (Session["Rol"].ToString() == "admin")
                    return View();
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
            
        }

        // POST: Uyelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "u_ID,Ad,Soyad,Mail,Nick,Parola,Tel,Foto,Rol")] Uyeler uyeler,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    byte[] _image = new byte[file.ContentLength];
                    file.InputStream.Read(_image, 0, file.ContentLength);
                    uyeler.Foto = _image;
                }
                db.Uyeler.Add(uyeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uyeler);
        }

        // GET: Uyelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Kid"] != null)
            {
                if (Session["Rol"].ToString() == "admin")
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Uyeler uyeler = db.Uyeler.Find(id);
                    if (uyeler == null)
                    {
                        return HttpNotFound();
                    }
                    return View(uyeler);
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
           
        }

        // POST: Uyelers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_ID,Ad,Soyad,Mail,Nick,Parola,Tel,Foto,Rol")] Uyeler uyeler,HttpPostedFileBase fileEdit)
        {
            if (ModelState.IsValid)
            {
                if (fileEdit != null)
                {
                    byte[] _imageEdit = new byte[fileEdit.ContentLength];
                    fileEdit.InputStream.Read(_imageEdit, 0, fileEdit.ContentLength);
                    uyeler.Foto = _imageEdit;
                }
                db.Entry(uyeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uyeler);
        }

        // GET: Uyelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Kid"] != null)
            {
                if (Session["Rol"].ToString() == "admin")
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Uyeler uyeler = db.Uyeler.Find(id);
                    if (uyeler == null)
                    {
                        return HttpNotFound();
                    }
                    return View(uyeler);
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
           
        }

        // POST: Uyelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uyeler uyeler = db.Uyeler.Find(id);
            db.Uyeler.Remove(uyeler);
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
