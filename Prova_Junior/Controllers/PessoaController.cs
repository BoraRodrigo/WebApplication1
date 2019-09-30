using Prova_Junior.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova_Junior.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult View()
        {
            return View(Pessoa.Lista_Cadastrar);
        }  
        public ActionResult Excluir_Pessoa(int id)
        {
            Pessoa pessoa = new Pessoa();
            return View(pessoa.retorna_Pessoa(id));
        }

        [HttpPost]
        public ActionResult Excluir_Pessoa(int id, FormCollection form)
        {
            Pessoa pessoa = new Pessoa();
            pessoa =(pessoa.retorna_Pessoa(id));
            pessoa.Excluir(pessoa);
            return RedirectToAction("View");
        }

        [HttpPost]
        public ActionResult Cadastrar(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return View(pessoa);
            }
            else
            {
                Pessoa.Lista_Cadastrar.Add(pessoa);
                ModelState.Clear();
              
                @ViewBag.Cadastrado_Com_Sucesso = "Cadastrado";
                return RedirectToAction("Listar_");
            }
            return View();
        }
        public ActionResult validacao_sexo(string sexo)
        {
            if (sexo.ToLower() == "m" || sexo.ToLower() == "f")
            {

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Listar_()
        {
            Pessoa pessoa = new Pessoa();
            return View(Pessoa.Lista_Cadastrar);
        }

    }
}