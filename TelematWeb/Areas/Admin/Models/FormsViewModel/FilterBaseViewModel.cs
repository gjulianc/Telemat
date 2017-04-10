using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelematWeb.Areas.Admin.Models.FormsViewModel
{
    public class FilterBaseViewModel
    {
        public string Base { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
    }
}