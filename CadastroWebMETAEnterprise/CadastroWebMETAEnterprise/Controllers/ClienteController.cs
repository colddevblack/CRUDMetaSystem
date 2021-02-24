using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroWebMETAEnterprise.Models;
using CadastroWebMETAEnterprise.EntityContext;

namespace CadastroWebMETAEnterprise.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
      

            private DataBaseContext db;

            public ClienteController()
            {
                db = new DataBaseContext();
            }

            public ActionResult ConsultaClientes()

            {
          
            return View(db.clientedb.ToList());
            }

        public ActionResult PesquisaClientes()

        {
            ViewBag.cliente = new SelectList(db.clientedb.ToList(), "id", "nomeCliente");
            ViewBag.telefone = new SelectList(db.clientedb.ToList(), "id", "telefone");
            ViewBag.dataNascimento = new SelectList(db.clientedb.ToList(), "id", "dataNascimento");
            return View(db.clientedb.ToList());
        }


        [HttpGet]
            public ActionResult CadastroCliente()
            {
                return View();
            }

            [HttpPost]
            public ActionResult CadastroCliente(ClienteModel clientemodref)
            {
                clientemodref.dataCriacao = DateTime.Now;
                db.clientedb.Add(clientemodref);
                db.SaveChanges();
                return RedirectToAction("ConsultaClientes");
            }

            [HttpGet]
            public ActionResult EditarCliente(int id)
            {
                var model = db.clientedb.Find(id);


                return View(model);
            }



            [HttpPost]
            public ActionResult EditarCliente(ClienteModel clientemodref)
            {
                 clientemodref.dataCriacao = DateTime.Now;
                db.Entry(clientemodref).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ConsultaClientes");
            }


            public ActionResult DeletarCliente(int Id)
            {

            var tr = db.orcadb.Find(Id);

            if (tr != null)
            {
                db.orcadb.Remove(tr);
            }
            
               
                var obj = db.clientedb.Find(Id);
                db.clientedb.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("ConsultaClientes");
            }

            [HttpGet]
            public ActionResult _BuscasCliente(int? idcliente, string idtelefone, DateTime? dataNasc)
            {
                {
                    // consulta linq
                    List<ClienteModel> cliente = (from u in db.clientedb
                                                  where (idcliente != null ? u.id == idcliente : 0 == 0)
                                                  && (idtelefone != null ? u.telefone == idtelefone : 0 == 0)
                                                  
                                                  select u
                                   ).ToList();

                    return PartialView(cliente);
                }
            }
        }
    }

