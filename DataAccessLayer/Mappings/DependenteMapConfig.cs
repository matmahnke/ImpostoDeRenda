using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    class DependenteMapConfig : EntityTypeConfiguration<Dependente>
    {
        public DependenteMapConfig()
        {
            this.ToTable("DEPENDENTES");
        }
    }
}
