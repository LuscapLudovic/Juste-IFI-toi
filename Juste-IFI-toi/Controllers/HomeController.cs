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
                User actUser = ((List<User>)Session["users"]).First();
                listRetards.Add(new Retard{Id = 1, Date = DateTime.Now, Note = 5, User = actUser, Motif = "C'est un retard", Photo = "/Images/giphy.gif"});
                listRetards.Add(new Retard{Id = 2, Date = DateTime.Now, Note = 10, User = new User{Id = 1, pseudo = "admin", password = "admin"}, Motif = "C'est deuxième retard", Photo = "/Images/giphy.gif"});
                listRetards.Add(new Retard{Id = 3, Date = DateTime.Now, Note = 7, User = new User{Id = 1, pseudo = "admin", password = "admin"}, Motif = "C'est troisieme retard", Photo = "/Images/giphy.gif"});
            }

            ViewBag.listRetards = listRetards.OrderBy(retard => retard.Note);
            
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