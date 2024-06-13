using Catalogos.Service.Queries.DTOs.CTIncidencias;
using Catalogos.Service.Queries.Queries.CTIncidencias;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTIncidencias
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/incidencias")]
    public class CTIncidenciaController : ControllerBase
    {
        private readonly ICTIncidenciaQueryService _incidencias;

        public CTIncidenciaController(ICTIncidenciaQueryService incidencias)
        {
            _incidencias = incidencias;
        }

        public async Task<List<CTIncidenciaDto>> GetAllCTIncidencias()
        {
            var incidencias = await _incidencias.GetAllCTIncidencias();
            return incidencias;
        }

        [HttpGet]
        [Route("getIncidenciasByServicio/{servicio}")]
        public async Task<List<CTIncidenciaDto>> GetIncidenciasByServicio(int servicio)
        {
            var incidencias = await _incidencias.GetIncidenciasByServicio(servicio);
            return incidencias;
        }


        [HttpGet]
        [Route("getIncidenciaById/{incidencia}")]
        public async Task<CTIncidenciaDto> GetIncidenciaById(int incidencia)
        {
            var incidencias = await _incidencias.GetIncidenciaById(incidencia);

            return incidencias;
        }

    }
}
