using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;
using Bonus.WebApi.ActionFilters;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Bonus.WebApi.Controllers
{
    [AuthorizationRequired]
    public class ProvinciaController : ApiController
    {
        #region Private variable.

        private readonly IProvinciaServices _services;

        #endregion

        #region Public Constructor

        public ProvinciaController(IProvinciaServices services)
        {
            _services = services;
        }

        #endregion

        /// <summary>
        /// Funncion para obtener las provincias.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Route("ObtenerProvincias")]
        [HttpGet]
        public List<ProvinciaEntity> ObtenerProvincias(string dptoCod)
        {
           return _services.ObtenerProvincias(dptoCod);
        }
    }
}
