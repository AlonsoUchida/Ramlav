using Bonus.BusinessEntities.DTO;
using System;
using System.Collections.Generic;

namespace Bonus.BusinessServices.Interfaces
{
    public interface IClienteServices
    {
        string ExisteCliente(short tipodoccod, string prsnrodoc);
        ClienteEntity ObtenerCliente(string prsCod);
        MovFideEntity ObtenerMovFidelizacion(string ctaPrsCod, int ctaCod);
        IEnumerable<CuentaEntity> ObtenerCuentas(string ctaPrsCod);
    }
}
