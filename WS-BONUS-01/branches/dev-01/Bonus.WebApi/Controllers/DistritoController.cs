using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;
using Bonus.WebApi.ActionFilters;
using System.Collections.Generic;
using System.Web.Http;

namespace Bonus.WebApi.Controllers
{
    [AuthorizationRequired]
    public class DistritoController : ApiController
    {
        #region Private variable.

        private readonly IDistritoServices _services;

        #endregion

        #region Public Constructor

        public DistritoController(IDistritoServices services)
        {
            _services = services;
        }

        #endregion

        [Route("ObtenerDistritos")]
        [HttpGet]
        public List<DistritoEntity> ObtenerDistritos(string dptoCod, string provCod)
        {
            return _services.ObtenerDistritos(dptoCod, provCod);
        }
    }
}
