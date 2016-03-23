using Bonus.BusinessEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus.BusinessServices.Interfaces
{
    public interface IDocumentoServices
    {
        /// <summary>
        /// Funncion para obtener los documentos.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        List<DocumentoEntity> ObtenerDocumentos();
    }
}
