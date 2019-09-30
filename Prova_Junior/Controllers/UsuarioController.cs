using Prova_Junior.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova_Junior.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        List<Noticia> Lista_De_Noticia_ADM = Noticia.Lista_Noticia();
       static List<Usuario> Lista_Usuario_Logado = new List<Usuario>();
       static  Usuario usuario_login = new Usuario();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar_Usuario()
        {
            return View();
        }
        public ActionResult Login_ADM()
        {
            return View();
        }
        public ActionResult LoginUSER()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Cadastrar_Noticia()
        {
            return View();
        }
        public ActionResult Menu_ADM()
        {
            return View();
        }
        public ActionResult Listar_Noticia()
        {
            return View(Lista_De_Noticia_ADM);
        }
        public ActionResult Todos_Noticias()
        {
            return View(Lista_De_Noticia_ADM);
        }


        public ActionResult TodasNoticias()
        {
            return View(Lista_De_Noticia_ADM);
        }
        

        [HttpPost]
        public ActionResult LoginUSER(string txt_Nome, string txt_Senha)
        {
            //Lista_Usuario_Logado= usuario_login.Lista_Login(txt_Nome,txt_Senha);

            //for (int i = 0; Lista_Usuario_Logado.Count < i; i++)
            //{
            //    if (Lista_Usuario_Logado[i].Nome.Equals(txt_Nome))
            //    {
            if (txt_Nome.Equals("User") && txt_Senha.Equals("User"))
            {
                return RedirectToAction("TodasNoticias");
            }
            // return RedirectToAction("Menu_ADM");
            //    }
            //}

            return View();
        }


        [HttpPost]
        public ActionResult Login_ADM(string txt_Nome, string txt_Senha)
        {
            //Lista_Usuario_Logado= usuario_login.Lista_Login(txt_Nome,txt_Senha);

            //for (int i = 0; Lista_Usuario_Logado.Count < i; i++)
            //{
            //    if (Lista_Usuario_Logado[i].Nome.Equals(txt_Nome))


            //    {
            if (txt_Nome.Equals("Admim")&&txt_Senha.Equals("Admim"))
            {
                return RedirectToAction("Menu_ADM");
            }
                   // return RedirectToAction("Menu_ADM");
            //    }
            //}
            
           return View();
        }

        public ActionResult Alterar_Noticia(int id)
        {
            Noticia noticia = new Noticia();
            return View(noticia.Lista_NoticiaID(id)[0]);
        }

        [HttpPost]
        public ActionResult Alterar_Noticia(Noticia noticia)
        {
            noticia.Alterar_Noticia(noticia);
            //return View();
            return RedirectToAction("Listar_Noticia");
        }

        [HttpPost]
        public ActionResult Excluir_(int id, FormCollection form)
        {
            Noticia noticia = new Noticia();
            noticia = noticia.Lista_NoticiaID(id)[0];
            noticia.Excluir(noticia);
            return RedirectToAction("View");
        }
        public ActionResult Excluir_(int id)
        {
            Noticia noticia = new Noticia();
            return View(noticia.Lista_NoticiaID(id)[0]);
        }


        [HttpPost]
        public ActionResult Cadastrar_Noticia(FormCollection form)
        {

            Noticia us1 = new Noticia();
            us1.Nome = form["txt_nome"];
            us1.Tipo = form["txt_tipo"];
            us1.Descricao = form["txt_descricao"];
            us1.Cadastrar_Noticia(us1);

            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar_Usuario( Usuario usario)
        {
            if (!ModelState.IsValid)
            {
                return View(usario);
            }
            else
            {
                usario.Cadastrar();
                ViewBag.Status = "Dados gravados com Êxito";
                ModelState.Clear();
                return RedirectToAction("Menu");
            }
            return View();
        }
        public ActionResult validacao_tipo(string tipo)
        {
            if (tipo.ToLower() == "A" || tipo.ToLower() == "U")
            {

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

    }
}

