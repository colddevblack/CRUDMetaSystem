using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroWebMETAEnterprise.Models;
using CadastroWebMETAEnterprise.EntityContext;

namespace CadastroWebMETAEnterprise.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Cliente
      

            private DataBaseContext db;

            public ProdutoController()
            {
                db = new DataBaseContext();
            }

            public ActionResult ConsultaProduto()
            {
          
            return View(db.produtodb.ToList());
            }

        public ActionResult PesquisaProduto()

        {
            ViewBag.produto = new SelectList(db.produtodb.ToList(), "id", "nomeProduto");
           
            
            return View(db.produtodb.ToList());
        }


        [HttpGet]
            public ActionResult CadastroProduto()
            {
                return View();
            }

            [HttpPost]
            public ActionResult CadastroProduto(ProdutoModel produtomodref)
            {
                produtomodref.dataCriacaoProduto = DateTime.Now;
                db.produtodb.Add(produtomodref);
                db.SaveChanges();
                return RedirectToAction("ConsultaProduto");
            }

            [HttpGet]
            public ActionResult EditarProduto(int id)
            {
                var model = db.produtodb.Find(id);


                return View(model);
            }



            [HttpPost]
            public ActionResult EditarProduto(ProdutoModel produtomodref)
            {
                produtomodref.dataCriacaoProduto = DateTime.Now;
                db.Entry(produtomodref).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ConsultaProduto");
            }


            public ActionResult DeletarProduto(int Id)
            {
            var tr = db.orcadb.Find(Id);

            if (tr != null)
            {
                db.orcadb.Remove(tr);
            }

            var obj = db.produtodb.Find(Id);
                db.produtodb.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("ConsultaProduto");
            }

            [HttpGet]
            public ActionResult _BuscasProduto(int? idproduto)
            {
                {
                    // consulta linq
                    List<ProdutoModel> queryprod = (from u in db.produtodb
                                                  where (idproduto != null ? u.id == idproduto : 0 == 0)
                                                  select u).ToList();

                    return PartialView(queryprod);
                }
            }
        }
    }

