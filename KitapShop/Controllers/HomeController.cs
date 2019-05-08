using KitapShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KitapShop.Controllers
{
    public class HomeController : Controller
    {
        KitapShopEntities db = new KitapShopEntities();
        // GET: Home
        public ActionResult Index()
        {
            var urunlistesi = db.Urunler.ToList();
            return View(urunlistesi);
        }
        public ActionResult giris()
        {
            if (Session["Kid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult giris(string uname,string psw)
        {
            var kullanici = db.Uyeler.SingleOrDefault(x => x.Nick == uname && x.Parola == psw);
            if(kullanici!=null)
            {
                Session["Kid"] = uname;
                Session["Rol"] = kullanici.Rol;
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult hakkimizda()
        {
            return View();
        }
        public ActionResult iletisim()
        {
            return View();
        }
        public ActionResult kayitol()
        {
            if (Session["Kid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult kayitol(string ad,string soyad,string nick,string parola,string mail,string tel,string Rol,HttpPostedFileBase kayitfoto,Uyeler uye)
        {
            if (Varmi(nick, mail))
            {
                if (ModelState.IsValid)
                {
                    uye.Ad = ad;
                    uye.Soyad = soyad;
                    uye.Nick = nick;
                    uye.Parola = parola;
                    uye.Mail = mail;
                    uye.Tel = tel;
                    if (kayitfoto != null)
                    {
                        byte[] _imageKayit = new byte[kayitfoto.ContentLength];
                        kayitfoto.InputStream.Read(_imageKayit, 0, kayitfoto.ContentLength);
                        uye.Foto = _imageKayit;
                    }
                    if(Rol==null)
                        uye.Rol = "uye";
                    db.Uyeler.Add(uye);
                    db.SaveChanges();
                    ViewBag.message = "Kayıt başarılı, şimdi giriş yapabilirsiniz.";
                    return View();
                }
                else
                    return View();
            }
            else
            {
                ViewBag.Hata = "Girmiş oldugunuz kullanici adi veya mail zaten kayitli";
                return View();
            }  
        }
        public ActionResult Magaza()
        {
            var res = db.Urunler.ToList();
            return View(res);
        }
        public ActionResult sepet()
        {
            if (Session["Kid"] != null)
            {
                var kullanici = Session["Kid"].ToString();
                var Kid = db.Uyeler.FirstOrDefault(x => x.Nick == kullanici);
                var sepet = db.Sepet.Where(x => x.uyeID == Kid.u_ID);
                return View(sepet);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult SepeteEkle(int? urunid,int? uyeid,Sepet sepet)
        {
            if (Session["Kid"] != null)
            {
                sepet.urunID = urunid;
                sepet.uyeID = uyeid;
                db.Sepet.Add(sepet);
                db.SaveChanges();
                return RedirectToAction("sepet", "Home");
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        [HttpGet]
        public ActionResult Urun(int? id)
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
        [HttpPost]
        public ActionResult Urun(int? id,string mesaj,Yorumlar yorum)
        {
            if (mesaj != null)
            {
                var nick = Session["Kid"].ToString();
                var res = db.Uyeler.FirstOrDefault(x => x.Nick == nick);
                yorum.uyeID = res.u_ID;
                yorum.Yorum = mesaj;
                yorum.kitapID = id;
                yorum.onay = 0;
                db.Yorumlar.Add(yorum);
                db.SaveChanges();
            }
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
        public ActionResult cikis()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public bool Varmi(string nick, string mail)
        {
            if (db.Uyeler.SingleOrDefault(x => x.Nick == nick || x.Mail == mail) == null)
                return true;
            else
                return false;
        }
    }
}