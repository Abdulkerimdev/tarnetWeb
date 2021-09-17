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
    public class BlogController : Controller
    {
        // GET: Blog
        private alloverMovieDB db = new alloverMovieDB();

        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.Blog.Include("Kategori").ToList().OrderByDescending(x => x.BlogId));
        }
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategori, "KategoriId", "KategoriAd");//veri taşıma işlemi 
            /*select listteki ilki parametre nereden geleceği
             * İkincisi neye göre seçileceği
             * üçüncüsü ise neyin döneceği
             */
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)//post create
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
                    string path = Path.Combine(Server.MapPath("~/Uploads"), "Blog", logoname);
                    img.Save(path);
                    blog.ResimUrl = "/Uploads/Blog/" + logoname;

                }
            }

            db.Blog.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var b = db.Blog.Where(x => x.BlogId == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategori, "KategoriId", "KategoriAd", b.KategoriId);
            return View(b);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Blog blog, HttpPostedFileBase ResimUrl)
        {

            if (ModelState.IsValid)
            {
                var b = db.Blog.Where(x => x.BlogId == id).SingleOrDefault();
                if (ResimUrl != null)
                {
                    if (System.IO.File.Exists(b.ResimUrl))
                    {
                        System.IO.File.Delete(b.ResimUrl);
                    }
                    WebImage img = new WebImage(ResimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ResimUrl.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Blog/" + logoname);

                    b.ResimUrl = "/Uploads/Blog/" + logoname;
                }
                b.Baslik = blog.Baslik;
                b.İcerik = blog.İcerik;
                b.KategoriId = blog.KategoriId;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(blog);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            var b = db.Blog.Find(id);
            if (id==null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(b.ResimUrl))
            {
                System.IO.File.Delete(b.ResimUrl);
            }
            db.Blog.Remove(b);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}