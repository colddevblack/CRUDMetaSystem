using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroWebMETAEnterprise.Models;
using CadastroWebMETAEnterprise.EntityContext;

namespace CadastroWebMETAEnterprise.Controllers
{
    public class GraphsController : Controller
    {
        private DataBaseContext db;

        public GraphsController()
        {
            db = new DataBaseContext();
        }
        public ActionResult Flot()
        {
            return View();
        }

        public ActionResult Morris()
        {
            return View();
        }

        public ActionResult Rickshaw()
        {
            return View();
        }

        public ActionResult Chartjs()
        {
            return View();
        }
        public ActionResult Chartist()
        {
            ViewBag.hoje = DateTime.Now;

            int cliente = db.clientedb.Count();

            ViewBag.cliente = cliente;

            int produto = db.produtodb.Count();

            ViewBag.produto = produto;

            return View();
        }
        public ActionResult Peity()
        {
            return View();
        }

        public ActionResult Sparkline()
        {
            return View();
        }

        public ActionResult C3charts()
        {
            return View();
        }
    }
}