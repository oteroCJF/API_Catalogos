using Catalogos.Service.Queries.DTOs.CTServicios;
using Catalogos.Service.Queries.Queries.CTServicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTServicios
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/servicios")]
    public class CTServicioContratoController : ControllerBase
    {
        private readonly ICTServicioQueryService _servicios;

        public CTServicioContratoController(ICTServicioQueryService servicios)
        {
            _servicios = servicios;
        }

        [HttpGet]
        public async Task<List<CTServicioDto>> GetAllServiciosAsync()
        {
            return await _servicios.GetAllServiciosAsync();
        }

        [Route("{servicio}")]
        [HttpGet]
        public async Task<CTServicioDto> GetServicioByIdAsync(int servicio)
        {
            return await _servicios.GetServicioByIdAsync(servicio);
        }
    }
}
