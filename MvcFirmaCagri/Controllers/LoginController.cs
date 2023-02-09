using MvcFirmaCagri.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcFirmaCagri.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbisTakipEntities db=new DbisTakipEntities();
        public ActionResult Index()
        {
            //Kullanici dogrulamasi icin
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblFirmalar P)
        {
            var bilgiler=db.TblFirmalar.FirstOrDefault(x=>x.Mail==P.Mail && x.Sifre==P.Sifre);
            if (bilgiler!=null)
            {

                FormsAuthentication.SetAuthCookie(bilgiler.Mail,false);
                Session["Mail"]=bilgiler.Mail.ToString();
                return RedirectToAction("AktifCagrilar","Default");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}