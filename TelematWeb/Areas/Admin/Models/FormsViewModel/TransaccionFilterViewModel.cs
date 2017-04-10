using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelematWeb.Areas.Admin.Models.FormsViewModel
{
    public class TransaccionFilterViewModel:FilterBaseViewModel
    {
        public string Vehiculo { get; set; }
        public int? RegistroDesde { get; set; }
        public int? RegistroHasta { get; set; }
        public int? UsuarioDesde { get; set; }
        public int? UsuarioHasta { get; set; }
        public string Carburante { get; set; }
        public string ModoUso { get; set; }
        public decimal? LitrosDesde { get; set; }
        public decimal? LitrosHasta { get; set; }
    }

    
}