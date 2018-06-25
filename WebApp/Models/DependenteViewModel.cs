using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class DependenteViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int ContribuinteID { get; set; }
    }
}