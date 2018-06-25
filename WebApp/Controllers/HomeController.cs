using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Contribuinte c = new Contribuinte();
            c.CPF = "00000000000";
            c.Nome = "Roberto";
            c.Renda = 123;
            var dependente = new Dependente() { Nome = "carlinhos", CPF = "00000000000" };
            //c.Dependente = new List<Dependente>() { dependente};
            BusinessRules.Impl.ContribuinteBusiness bll = new BusinessRules.Impl.ContribuinteBusiness();
            bll.Add(c);
            IList<Contribuinte> co = bll.GetAll();
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Imposto()
        {
            return View();
        }
    }
}
