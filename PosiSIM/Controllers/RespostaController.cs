using PosiSIM.DAO;
using PosiSIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PosiSIM.Controllers
{
    public class RespostaController : Controller
    {
  
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Listar_Async()
        {

            List<Resposta> respostas = await RespostaDAO.Busca_Respostas();
            return View(respostas);
        }

    }
}
