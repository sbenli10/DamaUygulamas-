using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DamaUygulaması.Controllers
{
    public class CheckerBoardController : Controller
    {

        // GET: CheckerBoard
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            // Oyun modu seçimine yönlendir
            return RedirectToAction("ChooseMode");
        }


        // GET: CheckerBoard/ChooseMode
        public ActionResult ChooseMode()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            return View(); // Views/CheckerBoard/ChooseMode.cshtml dosyasını yükler
        }


        // GET: CheckerBoard/PlayWithFriend
        public ActionResult PlayWithFriend()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            return View(); 
        }

       
        public ActionResult PlayWithAI()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            return View("AIView"); 
        }

        // GET: CheckerBoard/AIView
        public ActionResult AIView()
        {
            // Kullanıcı oturumda değilse, giriş sayfasına yönlendir
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            // Yapay zekaya karşı oynanacak özel görünüm sayfası
            return View("AIView");
        }



    }
}