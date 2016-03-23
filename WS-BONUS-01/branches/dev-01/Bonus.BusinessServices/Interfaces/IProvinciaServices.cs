using Bonus.BusinessEntities.DTO;
using System.Collections.Generic;

namespace Bonus.BusinessServices.Interfaces
{
    public interface IProvinciaServices
    {
        /// <summary>
        /// Funncion para obtener los distritos.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        List<ProvinciaEntity> ObtenerProvincias(string dptoCod);
    }
}
