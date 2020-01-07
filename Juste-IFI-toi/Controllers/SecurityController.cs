using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;
using Juste_IFI_toi.Models;

namespace Juste_IFI_toi.Controllers
{
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
                }

                string _pseudo = Request.Form.Get("pseudo");
                string _password = Request.Form.Get("password");

                if (listUser.Exists(user => user.pseudo == _pseudo && user.password == _password))
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
            return RedirectToRoute("/Home/Login");
        }
    }
}