using System.Collections.Generic;

namespace Entities
{
    public class Deposito : BaseEntity
    {
        public string Descripcion { get; set; }
        
        public virtual BaseRepostaje BaseRepostaje { get; set; }
        public virtual ICollection<Manguera> Mangueras { get; set; }
    }
}
