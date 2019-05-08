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
    public class UrunlersController : Controller
    {
        private KitapShopEntities db = new KitapShopEntities();

        // GET: Urunlers
        public ActionResult Index()
        {
            if (Session["Kid"] != null)
            {
                if (Session["Rol"].ToString() == "admin")
                    return View(db.Urunler.ToList());
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
            
        }

        // GET: Urunlers/Details/5
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
                    Urunler urunler = db.Urunler.Find(id);
                    if (urunler == null)
                    {
                        return HttpNotFound();
                    }
                    return View(urunler);
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
           
        }

        // GET: Urunlers/Create
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

        // POST: Urunlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ur_ID,Ad,Yazar,Cevirmen,Yayinevi,Dil,Kapak,Sayfa,Foto,Baslik,Aciklama,Fiyat")] Urunler urunler,HttpPostedFileBase ur_file)
        {
            if (ModelState.IsValid)
            {
                if (ur_file != null)
                {
                    byte[] _imageUrun = new byte[ur_file.ContentLength];
                    ur_file.InputStream.Read(_imageUrun, 0, ur_file.ContentLength);
                    urunler.Foto = _imageUrun;
                }
                db.Urunler.Add(urunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urunler);
        }

        // GET: Urunlers/Edit/5
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
                    Urunler urunler = db.Urunler.Find(id);
                    if (urunler == null)
                    {
                        return HttpNotFound();
                    }
                    return View(urunler);

                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
           
        }

        // POST: Urunlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ur_ID,Ad,Yazar,Cevirmen,Yayinevi,Dil,Kapak,Sayfa,Foto,Baslik,Aciklama,Fiyat")] Urunler urunler,HttpPostedFileBase ur_editFile)
        {
            if (ModelState.IsValid)
            {
                if (ur_editFile != null)
                {
                    byte[] _urImageEdit = new byte[ur_editFile.ContentLength];
                    ur_editFile.InputStream.Read(_urImageEdit, 0, ur_editFile.ContentLength);
                    urunler.Foto = _urImageEdit;
                }
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urunler);
        }

        // GET: Urunlers/Delete/5
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
                    Urunler urunler = db.Urunler.Find(id);
                    if (urunler == null)
                    {
                        return HttpNotFound();
                    }
                    return View(urunler);
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
           
        }

        // POST: Urunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urunler urunler = db.Urunler.Find(id);
            db.Urunler.Remove(urunler);
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
