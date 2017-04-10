using Data.Interfaz;
using Entities;

namespace Data.EFRepository
{
    public class TransaccionRepository:GenericRepository<Transaccion>,ITransaccionRepository
    {
        public TransaccionRepository()
        {

        }
    }
}
