using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskAyazMVC.AZ;
using TaskAyazMVC.Models;

namespace TaskAyazMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AyazEntities a = new AyazEntities();
            var res = a.BookDetails.ToList();
            List<EmpModel> book = new List<EmpModel>();
            foreach (var r in res)
            {
                book.Add(new EmpModel
                {
                    Id = r.Id,
                    Subject = r.Subject,
                    Book_Name = r.Book_Name,
                    Publication = r.Publication,
                    Author = r.Author
                });
            }
            return View(book);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(EmpModel obj)
        {
            AyazEntities db = new AyazEntities();
            BookDetail a = new BookDetail();
            a.Id = obj.Id;
            a.Subject = obj.Subject;
            a.Book_Name = obj.Book_Name;
            a.Publication = obj.Publication;
            a.Author = obj.Author;
            if (obj.Id == 0)
            {
                db.BookDetails.Add(a);
                db.SaveChanges();
            }
            else
            {
                db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult Delete(int Id)
        {
            AyazEntities f = new AyazEntities();
            var res = f.BookDetails.Where(m => m.Id == Id).First();
            f.BookDetails.Remove(res);
            f.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            AyazEntities f = new AyazEntities();
            EmpModel a = new EmpModel();
            var res = f.BookDetails.Where(m => m.Id == Id).First();
            a.Id = res.Id;
            a.Subject = res.Subject;
            a.Book_Name = res.Book_Name;
            a.Publication = res.Publication;
            a.Author = res.Author;
            return View("AddData", a);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login u)
        {
            AyazEntities i = new AyazEntities();
            var p = i.Authors.Where(m => m.Email == u.Email).FirstOrDefault();
            if (p == null)
            {
                TempData["Email"] = "Email not found";
            }
            else
            {
                if (p.Email == u.Email && p.Password == p.Password)
                {
                    FormsAuthentication.SetAuthCookie(u.First_Name, false);
                    Session["First_Name"] = p.First_Name;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Password"] = "Password not found";
                }
            }
            return View();
        }
         public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Email"] = null;
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(Author res)
        {
            AyazEntities f = new AyazEntities();
            f.Authors.Add(res);
            f.SaveChanges();
            return View();

        }
    }
}