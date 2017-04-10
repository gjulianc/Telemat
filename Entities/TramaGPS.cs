using System;

namespace Entities
{
    public class TramaGPS : BaseEntity
    {        
        public string Imei { get; set; }
        public string  Fecha { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public decimal Velocidad { get; set; }
        public decimal Rumbo { get; set; }
        public decimal Distancia { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
    }
}
