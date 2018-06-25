using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ContribuinteViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public double Renda { get; set; }
    }
    public class TabelaViewModel
    {
        public IList<ContribuinteViewModel> Contribuintes { get; set; }
        public IList<double> Imposto { get; set; }
    }
}