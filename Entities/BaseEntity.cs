using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaUltimaActualizacion { get; set; }
    }
}
