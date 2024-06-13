using Catalogos.Service.Queries.DTOs.CTServicios;
using Catalogos.Service.Queries.DTOs.CTServiciosContratos;
using Catalogos.Service.Queries.Queries.CTServicios;
using Catalogos.Service.Queries.Queries.CTServiciosContratos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTServiciosContratos
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/serviciosContrato")]
    public class CTServicioContratoController : ControllerBase
    {
        private readonly ICTServicioContratoQueryService _servicios;

        public CTServicioContratoController(ICTServicioContratoQueryService servicios)
        {
            _servicios = servicios;
        }

        [HttpGet]
        public async Task<List<CTServicioContratoDto>> GetAllServiciosAsync()
        {
            return await _servicios.GetAllServiciosContratoAsync();
        }

        [Route("getServiciosByServicio/{servicio}")]
        [HttpGet]
        public async Task<List<CTServicioContratoDto>> GetServiciosByServicioAsync(int servicio)
        {
            return await _servicios.GetServiciosByServicio(servicio);
        }
        
        [Route("getServicioContratoById/{scontrato}")]
        [HttpGet]
        public async Task<CTServicioContratoDto> GetServicioContratoById(int scontrato)
        {
            return await _servicios.GetServicioContratoById(scontrato);
        }
    }
}
