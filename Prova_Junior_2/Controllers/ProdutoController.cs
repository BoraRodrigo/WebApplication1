using Prova_Junior_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova_Junior_2.Controllers
{
    public class ProdutoController : Controller
    {
        List<Produto> produto_lista = Produto.Lista_Produto();

        List<Produto> produto_lista_Modelo_Celular = Produto.Lista_Produto_MODELO("Celular");
        List<Produto> produto_lista_Modelo_Tablet = Produto.Lista_Produto_MODELO("Tablet");
        List<Produto> produto_lista_Modelo_Not = Produto.Lista_Produto_MODELO("Not");
        List<Produto> produto_lista_Modelo_Carregadores = Produto.Lista_Produto_MODELO("Carregador");

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Celular()
        {
            return View(produto_lista_Modelo_Celular);
        }
        public ActionResult Not()
        {
            return View(produto_lista_Modelo_Not);
        }
        public ActionResult Tablet()
        {
            return View(produto_lista_Modelo_Tablet);
        }
        public ActionResult Carregadores()
        {
            return View(produto_lista_Modelo_Carregadores);
        }

        public ActionResult Alterar(int id)
        {

            Produto produto = new Produto();
            return View(produto.Lista_ProdutoID(id)[0]);

        }
        public ActionResult Dados_Produtos(int id)
        {

            Produto produto = new Produto();
            return View(produto.Lista_ProdutoID(id)[0]);
        }
        
        public ActionResult Excluir(int id)
        {
            Produto produto = new Produto();
            return View(produto.Lista_ProdutoID(id)[0]);
        }
        public ActionResult Listar()
        {
            return View(produto_lista);
        }
        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }
            else
            {
                produto.Cadastrar();
                ModelState.Clear();
                return Redirect("/Menu_/Menu_");
            }
        }
        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            produto.Alterar_Produto(produto);
            //return View();
            return Redirect("/Produto/Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int id, FormCollection form)
        {
            Produto produto = new Produto();
            produto = produto.Lista_ProdutoID(id)[0];
            produto.Excluir(produto);
            return Redirect("/Produto/Listar");
        }
    }
}