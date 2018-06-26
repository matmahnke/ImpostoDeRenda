using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ValuesController : Controller
    {
        public async Task<ActionResult> Index(double? SalarioMinimo)
        {
            try
            {
                using (var c = new HttpClient())
                {
                    string u = HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port;
                    c.BaseAddress = new Uri("http://" + u);
                    c.DefaultRequestHeaders.Accept.Clear();
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage res = await c.GetAsync("/api/Contribuintes/?SalarioMinimo="+ SalarioMinimo);

                    var data = await res.Content.ReadAsStringAsync();
                    TabelaViewModel t = JsonConvert.DeserializeObject<TabelaViewModel>(data);
                    List<ListViewModel> lista = new List<ListViewModel>();
                    for (int i = 0; i < t.Contribuintes.Count; i++)
                    {
                        lista.Add(new ListViewModel() { Nome = t.Contribuintes[i].Nome, Renda = t.Contribuintes[i].Renda , Imposto = t.Imposto[i]});
                    }
                    return View(lista.OrderBy(p => p.Nome).ThenBy(p => p.Imposto)); 
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(double SalarioMinimo)
        {
            // GET: Values/Create
            return RedirectToAction("Index", new { SalarioMinimo = SalarioMinimo});
        }
            public ActionResult Create()
        {
            return View();
        }

        // POST: Values/Create
        [HttpPost]
        public async Task<ActionResult> Create(ContribuinteViewModel contribuinte)
        {
            try
            {
                int ContribuinteID;
                using (var c = new HttpClient())
                {
                    string u = HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port;
                    c.BaseAddress = new Uri("http://"+u);
                    c.DefaultRequestHeaders.Accept.Clear();
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage res = await c.PostAsJsonAsync("/api/Contribuintes", contribuinte);
                    ContribuinteID = Convert.ToInt32(await res.Content.ReadAsStringAsync());

                }
                return RedirectToAction("Dependentes", new { ContribuinteID = ContribuinteID});
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dependentes(int ContribuinteID)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Dependentes(DependenteViewModel dependente)
        {
            try
            {
                using (var c = new HttpClient())
                {
                    string u = HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port;
                    c.BaseAddress = new Uri("http://" + u);
                    c.DefaultRequestHeaders.Accept.Clear();
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage res = await c.PostAsJsonAsync("/api/Dependentes", dependente);
                    ViewBag.Success = "Inserido com sucesso!";
                    return View();
                }
            }
            catch
            {
                ViewBag.Success = "Ocorreu um erro...";
                return View();
            }
        }
    }
}
