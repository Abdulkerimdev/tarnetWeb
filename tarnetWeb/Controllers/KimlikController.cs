using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using tarnetWeb.Models.DataContext;
using tarnetWeb.Models.Model;

namespace tarnetWeb.Controllers
{
    public class KimlikController : Controller
    {
        alloverMovieDB db = new alloverMovieDB();

        // GET: Kimlik
        public ActionResult Index()
        {
            
            return View(db.Kimliks.ToList());
        }



        // GET: Kimlik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kimlik/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimliks.Where(x => x.KimlikId == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken] // edit.cshtlm deki url güvenlik önlemini burada karşılayan kısım
        [ValidateInput(false)] // 'Request.Formda zararlı olabilecek form' hatası almamak için yapılıyor. 
        public ActionResult Edit(int id, Kimlik kimlik, HttpPostedFileBase LogoUrl)
        {
            if (ModelState.IsValid)
            {
                var kimlikTemp = db.Kimliks.Where(x => x.KimlikId == id).SingleOrDefault();
                if (LogoUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(kimlikTemp.Logo))) 
                        // bizim yüklediğimiz bir resim var mı onu kontrol edecek
                    {
                        System.IO.File.Delete(Server.MapPath(kimlikTemp.Logo));
                        //yüklemiş olduğumuz resmi siliyor.
                    }
                    WebImage img = new WebImage(LogoUrl.InputStream);
                    FileInfo imginfo = new FileInfo(LogoUrl.FileName);
                    string logoName = LogoUrl.FileName + imginfo.Extension; //yüklenen resmin ismini alıyor.
                    img.Save(@"~/Uploads/Kimlik/" + logoName);

                    kimlik.Logo = @"/Uploads/Kimlik/" + logoName;
                }
                kimlikTemp.Title = kimlik.Title;
                kimlikTemp.Keywords = kimlik.Keywords;
                kimlikTemp.Description = kimlik.Description;
                kimlikTemp.Link = kimlik.Link;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kimlik);
        }

        // GET: Kimlik/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kimlik/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
