using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Mvc;
using tarnetWeb.Models.DataContext;
using tarnetWeb.Models.Model;

namespace tarnetWeb.Controllers
{
    public class IcerikController : Controller
    {
        // GET: Icerik
        private alloverMovieDB db = new alloverMovieDB();
        public ActionResult Index()
        {
            return View(db.Icerik.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Icerik icerik, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    string logoname = "";
                    HttpPostedFileBase LogoByteData = Request.Files[0];
                    if (LogoByteData != null && LogoByteData.ContentLength > 0)
                    {
                        WebImage img = new WebImage(LogoByteData.InputStream);
                        FileInfo imgInfo = new FileInfo(LogoByteData.FileName);
                        logoname = Guid.NewGuid().ToString() + imgInfo.Extension;
                        string path = Path.Combine(Server.MapPath("~/Uploads"), "Icerik", logoname);
                        img.Save(path);
                        icerik.Logo = "/Uploads/Icerik/" + logoname;

                    }
                }

                db.Icerik.Add(icerik);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(icerik);
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                ViewBag.Uyari = "Güncellenecek içerik bulunamadı.";
            }
            var icerik = db.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            return View(icerik);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Icerik icerik, HttpPostedFileBase LogoByteData)
        {
           
            if (ModelState.IsValid)
            {
                var i = db.Icerik.Where(x => x.IcerikId == id).SingleOrDefault(); 
                if (LogoByteData != null)
                {
                    if (System.IO.File.Exists(i.Logo))
                    {
                        System.IO.File.Delete(i.Logo);
                    }
                    WebImage img = new WebImage(LogoByteData.InputStream);
                    FileInfo imginfo = new FileInfo(LogoByteData.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Icerik/" + logoname);

                    i.Logo= "/Uploads/Icerik/" + logoname;
                }
                i.Baslik = icerik.Baslik;
                i.Aciklama = icerik.Aciklama;
                i.CikisYil = icerik.CikisYil;
                i.Dil = icerik.Dil;
                i.IzlemeLink = icerik.IzlemeLink;
                i.YorumLink = i.YorumLink;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(icerik);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            var b = db.Icerik.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(b.Logo))
            {
                System.IO.File.Delete(b.Logo);
            }
            db.Icerik.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}