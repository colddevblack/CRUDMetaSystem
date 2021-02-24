using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroWebMETAEnterprise.Models;
using CadastroWebMETAEnterprise.EntityContext;

namespace CadastroWebMETAEnterprise.Controllers
{
    public class OrcamentoController : Controller
    {
        // GET: Cliente
      

            private DataBaseContext db;

            public OrcamentoController()
            {
                db = new DataBaseContext();
            }

            public ActionResult ConsultaOrcamento()
            {
          
            return View(db.orcadb.ToList());
            }

        public ActionResult PesquisaOrcamento()

        {
            ViewBag.Orcamento = new SelectList(db.orcadb.ToList(), "id", "valor");
           
            
            return View(db.orcadb.ToList());
        }


        [HttpGet]
            public ActionResult CadastroOrcamento()
            {

            ViewBag.clienteid = new SelectList(db.clientedb.ToList(), "id", "nomeCliente");
            ViewBag.produtoid = new SelectList(db.produtodb.ToList(), "id", "nomeProduto");

            return View();
            }

            [HttpPost]
            public ActionResult CadastroOrcamento(OrcamentoModel Orcamentomodref)
            {
                Orcamentomodref.dataCriacaoOrcamento = DateTime.Now;
                db.orcadb.Add(Orcamentomodref);
                db.SaveChanges();
                return RedirectToAction("ConsultaOrcamento");
            }

            [HttpGet]
            public ActionResult EditarOrcamento(int id)
            {
                var model = db.orcadb.Find(id);


                return View(model);
            }



            [HttpPost]
            public ActionResult EditarOrcamento(OrcamentoModel Orcamentomodref)
            {

                db.Entry(Orcamentomodref).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ConsultaOrcamento");
            }


            public ActionResult DeletarOrcamento(int Id)
            {
               
                var obj = db.orcadb.Find(Id);

         
            db.orcadb.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("ConsultaOrcamento");
            }

            [HttpGet]
            public ActionResult _BuscasOrcamento(int? idOrcamento)
            {
                {
                    // consulta linq
                    List<OrcamentoModel> queryorca = (from u in db.orcadb
                                                  where (idOrcamento != null ? u.id == idOrcamento : 0 == 0)
                                                  select u).ToList();

                    return PartialView(queryorca);
                }
            }
        }
    }

