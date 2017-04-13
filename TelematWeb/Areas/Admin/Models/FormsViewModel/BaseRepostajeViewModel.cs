using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelematWeb.Areas.Admin.Models.FormsViewModel
{
    public class BaseRepostajeViewModel
    {        
        public int Id { get; set; }
        public int Scu { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string CodigoPostal { get; set; }
        public string Delegacion { get; set; }
        public int ZonaHoraria { get; set; }
        public string Telefono { get; set; }
        public string PuertoComunicacion { get; set; }
        public string Baudios { get; set; }
        public string CodigoFlota { get; set; }
        public string CodigoControl { get; set; }
        public string CAE { get; set; }
        public string Descripcion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}