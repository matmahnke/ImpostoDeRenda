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
        public override void Validate(Contribuinte item)
        {
            base.Validate(item);
        }

        public void Add(Contribuinte item)
        {
            CurrentContext c = new CurrentContext();
            Validate(item);
            using(CurrentContext db = new CurrentContext())
            {
                db.Contribuintes.Add(item);
                db.SaveChanges();
            }
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
            using(CurrentContext db = new CurrentContext())
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
    }
}
