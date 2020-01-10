using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Juste_IFI_toi.Models;

namespace Juste_IFI_toi.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        
        public ActionResult Login()
        {
            if (Session["new_Error"] != null)
            {
                ViewBag.new_Error = Session["new_Error"];
                Session["new_Error"] = null;
            }
            
            if (Request.HttpMethod == "POST")
            {
                List<User> listUser = (List<User>) Session["users"];
                if (listUser == null)
                {
                    listUser = new List<User>();
                    listUser.Add(new User {pseudo = "admin", password = "admin"});
                    Session["users"] = listUser;
                }

                string _pseudo = Request.Form.Get("pseudo");
                string _password = Request.Form.Get("password");

                if (listUser.Exists(user => user.pseudo == _pseudo && user.password == _password))
                {
                    FormsAuthentication.RedirectFromLoginPage(Request.Form.Get("pseudo"), true);
                    User user = new User{Id = listUser[listUser.Count - 1].Id + 1, pseudo = _pseudo, password = _password};
                    HttpCookie userIdCookie = new HttpCookie("actUser");
                    userIdCookie.Value = user.Id.ToString();
                    Response.Cookies.Add(userIdCookie);
                    return RedirectToAction("Index", "Home");  
                }
                else
                {
                    ViewBag.Error = "Identifiant ou mot de passe incorrect";
                }
            }

            return View();
        }

        
        public ActionResult CreateAccount()
        {
            
            if (Request.HttpMethod == "POST")
            {
                string _pseudo = Request.Form.Get("new_pseudo");
                string _password = Request.Form.Get("new_password");

                if (_pseudo != "" && _password != "")
                {
                    User user = new User {pseudo = _pseudo, password = _password};
                    
                    List<User> listUser = (List<User>) Session["users"];
                    if (listUser == null)
                    {
                        listUser = new List<User>();
                    }
                    if (listUser.TrueForAll(user1 => user1.pseudo != _pseudo ))
                    {
                        listUser.Add(user);
                    }
                    else
                    {
                        Session["new_Error"] = "Le pseudo est déjà pris, essayer un autre pseudo";
                    }
                    Session["users"] = listUser;
                }
                else
                {
                    Session["new_Error"] = "veuillez renseigner tout les champs";
                }
            }

            return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["actUser"] = null;
            return RedirectToAction("Login");
        }
    }
}