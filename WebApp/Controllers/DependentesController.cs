using BusinessRules;
using BusinessRules.Impl;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class DependentesController : ApiController
    {
        // GET: api/Contribuintes
        public IEnumerable<Dependente> Get()
        {
            IList<Dependente> c = new DependenteBusiness().GetAll();
            return c;
        }

        // GET: api/Contribuintes/5
        public IEnumerable<Dependente> Get(int id)
        {
            IList<Dependente> c = new DependenteBusiness().GetAll();
            c.Where(d => d.ContribuinteID == id);
            return c;
        }

        // POST: api/Contribuintes
        public void Post([FromBody]WebApp.Models.DependenteViewModel value)
        {
            Dependente contribuinte = CustomAutoMapper<DTO.Dependente, WebApp.Models.DependenteViewModel>.Map(value);
            new DependenteBusiness().Add(contribuinte);
        }
    }
}
