using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno

        public static List<Aluno> listaAlunos = new List<Aluno>();
        string listadealunos;
        static int resultado = 0;
    
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Create()
        {
            return View();   
        }
        [HttpPost]
        public ActionResult Create(int txt_id, string txt_nome, int txt_idade)
        {
            if (txt_idade < 18)
            {
                ViewBag._mensagem = "A idade não pode ser menor que 18. Verefique a idade";
                ViewBag._id = txt_id;
                ViewBag._idade = txt_idade;
                ViewBag._nome = txt_nome;
            }
            else
            {
                Aluno aluno = new Aluno();
                aluno.Id_pessoa = txt_id;
                aluno.Idade = txt_idade;
                aluno.Nome = txt_nome;

                listaAlunos.Add(aluno);

                for (int i = 0; i < listaAlunos.Count; i++)
                {
                    listadealunos = listadealunos + ", " + listaAlunos[i].Nome;
                }

                ViewBag._lista = listadealunos;

                //parametro por viewBAG
                ViewBag._id = "";
                ViewBag._idade = "";
                ViewBag._nome = "";
                ViewBag._mensagem = "";

                ////parametro por viewDATA
                //ViewData["Id_Pessoa"] = aluno.Id_pessoa;
                //ViewData["Nome"] = aluno.Nome;
                //ViewData["Idade"] = aluno.Idade;
            }
            return View();
        }

        public ActionResult Soma()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Soma(int txt_valor)
        {
            resultado = (txt_valor + (resultado));
            ViewBag._valor = txt_valor;
            ViewData["resultado"] = resultado;

            if (resultado % 2 == 0)
            {
                ViewBag._tipo = "NUMERO PAR";
                ViewBag._cor = "color:forestgreen";

               
            }
            else
            {
                ViewBag._tipo = "NUMERO IMPAR";
                ViewBag._cor = "color:red";
 
            }
            return View();
        }
        public ActionResult New_Aluno()
        {
            return View();

        }
        [HttpPost]
        public ActionResult New_Aluno(FormCollection form)
        {

            Pessoa p1 = new Pessoa();
            p1.Nome = form["txt_nome"];
            p1.Idade = Convert.ToInt32(form["txt_idade"]);
            return View();

        }
        public ActionResult Novo_Aluno()
        {
            return View();
        }
        [HttpPost]
        // pra passar somente um objeto ou mais de um usar o colection.
        public ActionResult Novo_Aluno(Aluno aluno, FormCollection form)
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
            else if (aluno.Peso>300)
            {
                ModelState.AddModelError("", "*Campo Pesodeve ser menor que 300");
                validadados = false;
            }
            else if (aluno.Peso < 0) {
                ModelState.AddModelError("", "*Campo Peso de ser maior que 0");

                validadados = false;
            }
            try
            {
                if (validadados==true)
                {
                    aluno.Cadastrar();
                    ViewBag.Status = "Dados gravados com Êxito";
                    ModelState.Clear();
                    return View();
                }               
            }
            catch 
            {
            }
            return View();
        }
    }
}