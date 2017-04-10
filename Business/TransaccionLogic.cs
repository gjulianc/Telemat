using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TransaccionLogic
    {
        private TransaccionManager tmanager;
        public TransaccionManager TManager
        {
            get
            {
                return tmanager ?? (tmanager = new TransaccionManager());
            }
        }

        //public List<Transaccion> GetTransacciones()
        //{
        //    return TManager.GetAllTransacciones().ToList();
        //}

        //public void InsertarTransaccion(Transaccion transaccion)
        //{
        //    TManager.InsertTransaccion(transaccion);
        //}
    }
}
