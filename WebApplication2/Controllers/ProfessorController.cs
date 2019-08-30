using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        static List<String> listaCpf = new List<string>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return View(professor);
            }
            else
            {
                List<String> minha_lista = new List<string>();
                if (Session["lista_de_cpf"] != null)
                {
                    minha_lista = (List<String>)Session["lista_de_cpf"];
                }
                minha_lista.Add(professor.Cpf);
                Session["lista_de_cpf"] = minha_lista;
                return View();
            }

            return View(professor);
        }

        public ActionResult validacao(string sexo)
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
        public ActionResult validacao_cpf(string cpf, string email)
        {
            if (!email.Contains("@"))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            if (Session["lista_de_cpf"] != null)
            {

                List<String> mnha_lista_Cpf = new List<string>();
                mnha_lista_Cpf = (List<String>)Session["lista_de_cpf"];
                if (mnha_lista_Cpf.Contains(cpf))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            //        int i = 0;
            //        do
            //        {

            //            if (listaCpf[i].Equals(cpf))
            //            {
            //                i = i + 1;

            //                return Json(true, JsonRequestBehavior.AllowGet);
            //              }
            //            else
            //            {
            //                listaCpf.Add(cpf);
            //                return Json(false, JsonRequestBehavior.AllowGet);

            //            }
            //        } while (i==listaCpf.Count);


            //        return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
    
}