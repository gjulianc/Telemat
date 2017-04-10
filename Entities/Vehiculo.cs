using System.Collections.Generic;

namespace Entities
{
    public class Vehiculo:BaseEntity
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public virtual ICollection<Transaccion> Transacciones { get; set; }
        public virtual ICollection<TramaGPS> Tramas { get; set; }
    }
}
