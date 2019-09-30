using Prova_Junior_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova_Junior_2.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa

        List<Pessoa> pessoas_lista = Pessoa.Lista_Pessoa();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Alterar(int id)
        {

            Pessoa pessoa = new Pessoa();
            return View(pessoa.Lista_NoticiaID(id)[0]);
           
        }
        public ActionResult Excluir(int id)
        {
            
                Pessoa pessoa = new Pessoa();
                return View(pessoa.Lista_NoticiaID(id)[0]);           
        }
        public ActionResult Listar()
        {
            return View(pessoas_lista);
        }
        [HttpPost]
        public ActionResult Cadastrar(Pessoa pessoa)
        {
            pessoa.Cadastrar();
            ModelState.Clear();
            return Redirect("/Menu_/Menu_");
        }
        [HttpPost]
        public ActionResult Alterar(Pessoa pessoa)
        {
            pessoa.Alterar_Pessoa(pessoa);
            //return View();
            return Redirect("/Pessoa/Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int id, FormCollection form)
        {
            Pessoa pessoa = new Pessoa();
            pessoa = pessoa.Lista_NoticiaID(id)[0];
            pessoa.Excluir(pessoa);
            return Redirect("/Pessoa/Listar");
        }


    }
}