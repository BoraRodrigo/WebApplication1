using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CadastrarPessoaController : Controller
    {
        // GET: CadastrarPessoa
        List<Pessoa> pessoas = Pessoa.Lista_Pessoas();
    
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Menu_()
        {
            return View();
        }
        public ActionResult Alterar_()
        {
            return View();
        }
        public ActionResult Cadastrar_()
        {
            return View();
        }
        public ActionResult Listar_()
        {
            return View(pessoas);
        }
        public ActionResult Login_()
        {
            return View();
        }

        public ActionResult ListaTodos()
        {
            return View(pessoas);
        }
      
        public ActionResult EditarTodos(int id)
        {
            Pessoa pessoa = new Pessoa();
            return View(pessoa.Lista_Pessoas_ID(id)[0]);
        }


        [HttpPost]
        public ActionResult EditarTodos(Aluno aluno)
        {
            aluno.Alterar(aluno);
            //return View();
            return RedirectToAction("ListaTodos");
        }
        [HttpPost]
        public ActionResult Excluir_(int id, FormCollection form)
        {
            Pessoa pessoa = new Pessoa();
            pessoa=pessoa.Lista_Pessoas_ID(id)[0];
            pessoa.Excluir(pessoa);
            return RedirectToAction("ListaTodos");
        }
        public ActionResult Excluir_(int id )
        {
            Pessoa pessoa = new Pessoa();
            return View(pessoa.Lista_Pessoas_ID(id)[0]);
        }
        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno, FormCollection form)
        {
                bool validadados = true;

                if (string.IsNullOrEmpty(aluno.Nome))
                {
                    ModelState.AddModelError("", "Campo nome obrigatorio");
                    validadados = false;
                }

                if (!aluno.Idade.HasValue)
                {
                    ModelState.AddModelError("", "Campo idade obrigatorio");
                    validadados = false;
                }

                if (string.IsNullOrEmpty(aluno.Sexo))
                {
                    ModelState.AddModelError("Sexo", "*Campo Sexo é obrigatorio");
                    validadados = false;
                }
                else if (aluno.Sexo != ("F") && (aluno.Sexo != ("M")))
                {
                    ModelState.AddModelError("", "*Campo sexo tem que ser M ou F");
                    validadados = false;
                }

                if (!aluno.Peso.HasValue)
                {
                    ModelState.AddModelError("Peso", "*Campo Peso é obrigatorio");
                    validadados = false;
                }
                else if (aluno.Peso > 300)
                {
                    ModelState.AddModelError("", "*Campo Pesodeve ser menor que 300");
                    validadados = false;
                }
                else if (aluno.Peso < 0)
                {
                    ModelState.AddModelError("", "*Campo Peso de ser maior que 0");

                    validadados = false;
                }
                try
                {
                    if (validadados == true)
                    {
                        aluno.Cadastrar();
                        ViewBag.Status = "Dados gravados com Êxito";
                        ModelState.Clear();
                    return RedirectToAction("Login_");
                    
                    }
                }
                catch
                {
                }
                return View();
        }

        [HttpPost]
        public ActionResult Login_(string Nome, String Cpf)
        {
            return RedirectToAction("Menu_");
        }         
    }
}