using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova_Junior_2.Controllers
{
    public class Menu_Controller : Controller
    {
        // GET: Menu_
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu_()
        {
            return View();
        }
        public ActionResult Menu_USUARIO()
        {
            return View();
        }
        

        // return Redirect("/Menu/EsporteUsuario"); Retona para view de fora da pagina
    }
}