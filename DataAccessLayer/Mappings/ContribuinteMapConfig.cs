using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    class ContribuinteMapConfig : EntityTypeConfiguration<Contribuinte>
    {
        public ContribuinteMapConfig()
        {
            this.ToTable("CONTRIBUINTES");
            this.Property(p => p.CPF).HasMaxLength(14);
            this.Property(p => p.Nome).HasMaxLength(100);
            //this.HasRequired(p => p.Dependentes).WithMany().WillCascadeOnDelete(false);
        }
    }
}
