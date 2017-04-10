using Data.EFRepository;
using System;

namespace Data.Interfaz
{
    public interface ITelematContext: IDisposable
    {
        TelematContext service();
    }
}
