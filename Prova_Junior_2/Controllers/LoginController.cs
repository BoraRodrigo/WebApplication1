using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova_Junior_2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txt_Nome, string txt_Senha)
        {
            if (txt_Nome.Equals("adm") && txt_Senha.Equals("123"))
            {
                return Redirect("/Menu_/Menu_");
            }else if (txt_Nome.Equals("User") && txt_Senha.Equals("123"))
            {
                return Redirect("/Menu_/Menu_USUARIO");
            }
            else
            {
                return Redirect("/Login/Login");
            }
            return View();
        }
    }
}