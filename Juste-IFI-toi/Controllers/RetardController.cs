using Juste_IFI_toi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juste_IFI_toi.Controllers
{
    public class RetardController : Controller
    {
        // GET: Retard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateRetard(HttpPostedFileBase file)
        {
            if(Request.HttpMethod == "POST")
            {
                Retard retard = new Retard();
                User user = ((List<User>)Session["users"]).First();
                DateTime date = DateTime.Today;                
                string motif = Request.Form.Get("motif");
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"),
                                                   Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }
                string photo = file.FileName;
                retard.Date = date;
                retard.User = user;
                retard.Motif = motif;
                retard.Photo = "/Images/" + photo;

                List<Retard> listRetards = (List<Retard>)Session["Retards"];
                if(listRetards == null)
                {
                    listRetards = new List<Retard>();
                }
                listRetards.Add(retard);

                Session["Retards"] = listRetards;
            }
            return View();
        }
        //TODO ça marche pas ptdr
        public ActionResult Up(Retard retard)
        {                        
            retard.Note++;
            return View(retard.Note);
        }

        // ça non plus mdr
        public ActionResult Down(Retard retard)
        {
            retard.Note--;
            return View(retard.Note);
        }
    }
}