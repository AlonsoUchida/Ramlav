using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;
using Bonus.WebApi.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bonus.WebApi.Controllers
{
    [AuthorizationRequired]
    public class DepartamentoController : ApiController
    {
        #region Private variable.

        private readonly IDepartamentoServices _services;

        #endregion

        #region Public Constructor

        public DepartamentoController(IDepartamentoServices services)
        {
            _services = services;
        }

        #endregion

        [Route("ObtenerDepartamentos")]
        [HttpGet]
        public List<DepartamentoEntity> ObtenerDepartamentos()
        {
            return _services.ObtenerDepartamentos();
        }

    }
}
