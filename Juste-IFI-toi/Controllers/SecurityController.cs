using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace Juste_IFI_toi.Controllers
{
    public class SecurityController : Controller
    {
        
        public ActionResult Login()
        {
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form.Get("pseudo") == "admin" && Request.Form.Get("password") == "admin" )
                {
                    FormsAuthentication.RedirectFromLoginPage(Request.Form.Get("pseudo"), true);
                    return RedirectToAction("Index", "Home");  
                }
                else
                {
                    ViewBag.Error = "Identifiant ou mot de passe incorrect";
                }
            }

            return View();
        }


        public ActionResult Logout()
        {
            return RedirectToRoute("/Home/Login");
        }
    }
}