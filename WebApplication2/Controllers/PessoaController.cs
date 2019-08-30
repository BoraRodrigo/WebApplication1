using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa

            public ActionResult Details()
             {
            Pessoa p1 = new Pessoa();
            p1.Id_pessoa = 3;
            p1.Idade = 78;
            p1.Nome = "Helem";

            

            return View(p1);
             }
        public ActionResult Index()
        {
            ViewData["Id_Pessoa"] = 1;
            ViewData["Nome"] = "Fabiano";
            ViewData["Idade"] = 40;

            Pessoa p1 = new Pessoa();
            p1.Id_pessoa = 2;
            p1.Idade = 24;
            p1.Nome = "MarcAO";


            ViewBag._id = p1.Id_pessoa;
            ViewBag._idade = p1.Idade;
            ViewBag._nome = p1.Nome;


            return View();
        }
    }
}