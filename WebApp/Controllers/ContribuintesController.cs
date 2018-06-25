using BusinessRules;
using BusinessRules.Impl;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ContribuintesController : ApiController
    {
        private ContribuinteBusiness Business = new ContribuinteBusiness();

        // GET: api/Contribuintes
        public IEnumerable<Contribuinte> Get()
        {
            IList<Contribuinte> c = new ContribuinteBusiness().GetAll();
            return c;
        }

        // GET: api/Contribuintes/?SalarioMinimo=5
        public TabelaViewModel GetIR(double SalarioMinimo)
        {
            var t = Business.ImpostoDeRenda(SalarioMinimo);
            TabelaViewModel tabela = new TabelaViewModel();
            tabela.Contribuintes = new List<ContribuinteViewModel>();
            foreach (var item in t.Contribuintes)
            {
                tabela.Contribuintes.Add(CustomAutoMapper<ContribuinteViewModel, Contribuinte>.Map(item));
            }
            tabela.Imposto = t.Imposto;
            return tabela;
        }

        // GET: api/Contribuintes/5
        public Contribuinte GetByID(int id)
        {
            Contribuinte c = new ContribuinteBusiness().GetByID(id);
            return c;
        }

        // POST: api/Contribuintes
        public int Post([FromBody]WebApp.Models.ContribuinteViewModel value)
        {
            Contribuinte contribuinte = CustomAutoMapper<DTO.Contribuinte, WebApp.Models.ContribuinteViewModel>.Map(value);
            return Business.Add(contribuinte);
            //new ContribuinteBusiness().Add(contribuinte);
        }
    }
}
