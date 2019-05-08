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
    public class YorumlarsController : Controller
    {
        private KitapShopEntities db = new KitapShopEntities();

        // GET: Yorumlars
        public ActionResult Index()
        {
            if (Session["Kid"] != null)
            {
                if (Session["Rol"].ToString() == "admin")
                {
                    var yorumlar = db.Yorumlar.Include(y => y.Uyeler);
                    return View(yorumlar.ToList());
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
            
        }

        // GET: Yorumlars/Details/5
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
                    Yorumlar yorumlar = db.Yorumlar.Find(id);
                    if (yorumlar == null)
                    {
                        return HttpNotFound();
                    }
                    return View(yorumlar);
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
            
        }

        // GET: Yorumlars/Edit/5
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
                    Yorumlar yorumlar = db.Yorumlar.Find(id);
                    if (yorumlar == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.uyeID = new SelectList(db.Uyeler, "u_ID", "Ad", yorumlar.uyeID);
                    return View(yorumlar);
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
            
        }

        // POST: Yorumlars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "y_ID,Yorum,uyeID,kitapID,Yorum,onay")] Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorumlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.uyeID = new SelectList(db.Uyeler, "u_ID", "Ad", yorumlar.uyeID);
            return View(yorumlar);
        }

        // GET: Yorumlars/Delete/5
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
                    Yorumlar yorumlar = db.Yorumlar.Find(id);
                    if (yorumlar == null)
                    {
                        return HttpNotFound();
                    }
                    return View(yorumlar);
                }
                else
                    return RedirectToAction("giris", "Home");
            }
            else
            {
                return RedirectToAction("giris", "Home");
            }
            
        }

        // POST: Yorumlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorumlar yorumlar = db.Yorumlar.Find(id);
            db.Yorumlar.Remove(yorumlar);
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
