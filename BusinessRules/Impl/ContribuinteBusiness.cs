using BusinessRules.Interfaces;
using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Impl
{
    public class ContribuinteBusiness : BaseValidator<Contribuinte>, IEntityBase<Contribuinte>
    {
        private delegate IEnumerable<Dependente> filtra();
        public override void Validate(Contribuinte item)
        {
            base.Validate(item);
        }

        public int Add(Contribuinte item)
        {
            CurrentContext c = new CurrentContext();
            Validate(item);
            using (CurrentContext db = new CurrentContext())
            {
                item = db.Contribuintes.Add(item);
                db.SaveChanges();
            }
            return item.ID.Value;
        }

        public void Edit(Contribuinte item)
        {
            Validate(item);
            using (CurrentContext db = new CurrentContext())
            {
                db.Entry<Contribuinte>(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Contribuinte item)
        {
            throw new NotImplementedException("Exclusão não implementada");
        }

        public Contribuinte GetByID(int id)
        {
            using (CurrentContext db = new CurrentContext())
            {
                return db.Contribuintes.Find(id);
            }
        }

        public IList<Contribuinte> GetAll()
        {
            using (CurrentContext db = new CurrentContext())
            {
                return db.Contribuintes.AsNoTracking().ToList();
            }
        }

        public Tabela ImpostoDeRenda(double SalarioMinimo)
        {
            Tabela tabela = new Tabela();
            tabela.Contribuintes = new List<Contribuinte>();
            tabela.Imposto = new List<double>();
            IEnumerable<Contribuinte> contribuintes = GetAll();
            foreach (Contribuinte c in contribuintes)
            {
                IEnumerable<Dependente> dependentes = dep(c.ID.Value);
                double rendaLiquida = c.Renda - (((dependentes.Count() * 5.0) / 100.0) * c.Renda);
                double porcentagem = calculaImposto(rendaLiquida, SalarioMinimo);
                tabela.Contribuintes.Add(c);
                tabela.Imposto.Add((rendaLiquida / 100.0)*porcentagem);
            }
            return tabela;
        }
        /// <param name="l">renda liquida</param>
        /// <param name="s">salario minimo</param>
        private double calculaImposto(double l, double s)
        {
            if (l <= s * 2)
                return 0;
            else if (l > s * 2 && l <= s * 4)
                return 7.5D;
            else if (l > s * 4 && l <= s * 5)
                return 15D;
            else if (l > s * 5 && l <= s * 7)
                return 22.5D;
            else if (l > s * 7)
                return 27.5D;
            else
                return 0;
        }
        private IEnumerable<Dependente> dep(int id) => new DependenteBusiness().GetAll().Where(c => c.ContribuinteID == id);
    }
}
