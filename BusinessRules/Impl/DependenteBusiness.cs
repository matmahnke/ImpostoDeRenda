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
    public class DependenteBusiness : BaseValidator<Dependente>, IEntityBase<Dependente>
    {
        public override void Validate(Dependente item)
        {
            base.Validate(item);
        }

        public void Add(Dependente item)
        {
            CurrentContext c = new CurrentContext();
            Validate(item);
            using (CurrentContext db = new CurrentContext())
            {
                db.Dependentes.Add(item);
                db.SaveChanges();
            }
        }

        public void Edit(Dependente item)
        {
            Validate(item);
            using (CurrentContext db = new CurrentContext())
            {
                db.Entry<Dependente>(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Dependente item)
        {
            throw new NotImplementedException("Exclusão não implementada");
        }

        public Dependente GetByID(int id)
        {
            using (CurrentContext db = new CurrentContext())
            {
                return db.Dependentes.Find(id);
            }
        }

        public IList<Dependente> GetAll()
        {
            using (CurrentContext db = new CurrentContext())
            {
                return db.Dependentes.AsNoTracking().ToList();
            }
        }
    }
}
