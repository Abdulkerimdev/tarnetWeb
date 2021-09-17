using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tarnetWeb.Models;
using tarnetWeb.Models.DataContext;
using tarnetWeb.Models.Model;

namespace tarnetWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        

        alloverMovieDB db = new alloverMovieDB();  
        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            if (login != null)
            {
                if (login.Eposta == admin.Eposta && login.Sifre == admin.Sifre)
                {
                    Session["adminId"] = login.AdminId;
                    Session["eposta"] = login.Eposta;
                    return RedirectToAction("Index", "Admin");// işlem tamamsa adminin indexine gidecek
                }
            }
           
            ViewBag.Uyari = "Kullanıcı adı veya şifre hatalı! Tısss";
            return View(admin);
        }

        public ActionResult Logout()
        {
            Session["adminId"] = null;
            Session["eposta"] = null;
            Session.Abandon();

            return RedirectToAction("Login", "Admin");
        }
    }
}