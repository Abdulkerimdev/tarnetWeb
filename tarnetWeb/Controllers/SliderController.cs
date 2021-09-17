using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using tarnetWeb.Models.DataContext;
using tarnetWeb.Models.Model;

namespace tarnetWeb.Controllers
{
    public class SliderController : Controller
    {
        private alloverMovieDB db = new alloverMovieDB();

        // GET: Sliders
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider, HttpPostedFileBase ResimURL)
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
                        string path = Path.Combine(Server.MapPath("~/Uploads"), "Slider", logoname);
                        img.Save(path);
                        slider.ResimURL = "/Uploads/Slider/" + logoname;
                    }
                }
                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek içerik bulunamadı.";
            }
            var slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase LogoByteData, Slider slider)
        {
            if (ModelState.IsValid)
            {
                var i = db.Slider.Where(x => x.SliderId == id).SingleOrDefault();
                if (LogoByteData != null)
                {
                    if (System.IO.File.Exists(i.ResimURL))
                    {
                        System.IO.File.Delete(i.ResimURL);
                    }
                    WebImage img = new WebImage(LogoByteData.InputStream);
                    FileInfo imginfo = new FileInfo(LogoByteData.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Slider/" + logoname);

                    i.ResimURL = "/Uploads/Slider/" + logoname;
                }
                i.Başlik= slider.Başlik;
                i.Aciklama = slider.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Slider.Find(id);
            db.Slider.Remove(slider);
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
