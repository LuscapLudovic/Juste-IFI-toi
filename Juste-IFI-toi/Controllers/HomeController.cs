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
            
            ViewBag.listRetards = listRetards.OrderBy(retard =>  retard.Note);
            
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