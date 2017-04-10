namespace Entities
{
    public class Manguera : BaseEntity
    {
        public int Numero { get; set; }

        public virtual Deposito Deposito { get; set; }
    }
}
