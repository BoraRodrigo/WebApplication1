using PosiSIM.DAO;
using PosiSIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PosiSIM.Controllers
{
    public class Dados_PesquisaController : Controller
    {
        // GET: Dados_Pesquisa
        public ActionResult Index()
        {
            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> Listar_Async()
        {

            List<Dados_Pesquisa> dados_Pesquisas = await Dados_Pesquisa_DAO.Dados_Pesquisa();
            return View(dados_Pesquisas);
        }
    }
}