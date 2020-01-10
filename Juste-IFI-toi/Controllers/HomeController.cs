using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juste_IFI_toi.Models;

namespace Juste_IFI_toi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<Retard> listRetards = (List<Retard>)Session["Retards"];

            if (listRetards == null)
            {
                listRetards = new List<Retard>();
                listRetards.Add(new Retard{Id = 1, Date = DateTime.Now, Note = 5, User = new User{Id = 1, pseudo = "admin", password = "admin"}, Motif = "C'est un retard", Photo = "oui"});
                listRetards.Add(new Retard{Id = 2, Date = DateTime.Now, Note = 10, User = new User{Id = 1, pseudo = "admin", password = "admin"}, Motif = "C'est deuxième retard", Photo = "oui"});
                listRetards.Add(new Retard{Id = 3, Date = DateTime.Now, Note = 7, User = new User{Id = 1, pseudo = "admin", password = "admin"}, Motif = "C'est troisieme retard", Photo = "oui"});

            }
            
            ViewBag.listRetards = listRetards;
            
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}