using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        FACEAR_2019Entities1 db = new FACEAR_2019Entities1();//conecao (Web config)
        public ActionResult Index()
        {
            var listagem = db.Produto_.ToList();
            return View(listagem);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var produto = db.Produto_.Find(id);
            return View(produto);
        }
        public ActionResult Delete(int id)
        {
            var produto = db.Produto_.Find(id);
            return View(produto);
        }
        [HttpPost]
        public ActionResult Delete(Produto_ produto_)
        {
            try
            {
                var p = db.Produto_.Find(produto_.Id_Produto);

                db.Produto_.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("",ex.Message.ToString());
                return View(produto_);
            }
        
        }

        [HttpPost]
        public ActionResult Edit(Produto_ produto_)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    db.Entry(produto_).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("",ex.Message.ToString());
                    return View(produto_);
                }
          
            }
            else
            {
                return View(produto_);
            }
        }
        [HttpPost]
        public ActionResult Create(Produto_ produto)
        {

            if (ModelState.IsValid==true)
            {
                try
                {
                    db.Produto_.Add(produto);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(produto);

                }
            }
            else
            {
                ModelState.AddModelError("","Existem campos incorretos");
                return View(produto);
            }
          
        }
    }
}