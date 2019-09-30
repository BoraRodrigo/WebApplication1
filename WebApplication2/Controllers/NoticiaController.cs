using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class NoticiaController : Controller
    {
        // GET: Noticia
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            List<Noticia> lista_noticia = new List<Noticia>();
            if (Session["Noticia"] != null)
            {
                lista_noticia = (List<Noticia>)Session["Noticia"];
            }
            Noticia n1 = new Noticia();
            n1=  (Noticia)lista_noticia.Find(x => x.ID == id);
            return View(n1);
        }
        public ActionResult Noticia()
        {

            List<Noticia> lista_noticia = new List<Noticia>();
            if (Session["Noticia"] != null)
            {
                lista_noticia = (List<Noticia>)Session["Noticia"];
            }
            else
            {
                Noticia n1 = new Noticia();
                n1.ID = 0;
                n1.Id_topico = 0;
                n1.Titulo = "Neymar";
                n1.Descricao = "Só cai";
                lista_noticia.Add(n1);

                Noticia n2 = new Noticia();
                n2.ID = 1;
                n2.Id_topico = 1;
                n2.Titulo = "Lula";
                n2.Descricao = "Só fica preso";
                lista_noticia.Add(n2);


                Noticia n3 = new Noticia();
                n3.ID = 2;
                n3.Id_topico = 2;
                n3.Titulo = "Crime";
                n3.Descricao = "Só morte";

                lista_noticia.Add(n3);

                Session["Noticia"] = lista_noticia;

            }
            return View(lista_noticia);
        }
    }
}