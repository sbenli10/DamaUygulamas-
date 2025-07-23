using DamaUygulaması.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DamaUygulaması.Controllers
{
    public class AccountController : Controller
    {
         private GameDbContext db = new GameDbContext();

        // GET: /Account/Register

        // GET: /Account/Index
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Username = Session["Username"];
            ViewBag.Role = Session["Role"];
            return View();
        }

        public ActionResult Register() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user, string password, string confirmPassword)
        {
            // Hata buradan geliyor, bu satır eklenecek:
            ModelState.Remove("PasswordHash");

            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Username == user.Username))
                {
                    ModelState.AddModelError("", "Kullanıcı adı zaten mevcut.");
                    return View();
                }

                if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                {
                    ModelState.AddModelError("", "Şifre en az 6 karakter olmalıdır.");
                    return View(user);
                }

                if (password != confirmPassword)
                {
                    ModelState.AddModelError("", "Şifreler eşleşmiyor.");
                    return View(user);
                }

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
                db.Users.Add(user);
                db.SaveChanges();

                TempData["Success"] = "Kayıt başarılı, şimdi giriş yapabilirsiniz.";
                return RedirectToAction("Login");
            }

            return View(user);
        }



        // GET: /Account/Login
        public ActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                Session["UserId"] = user.Id;
                Session["Username"] = user.Username;
                Session["Role"] = user.Role;
                return RedirectToAction("Index", "CheckerBoard");
            }

            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}