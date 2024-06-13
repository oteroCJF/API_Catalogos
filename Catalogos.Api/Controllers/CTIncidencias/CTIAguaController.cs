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
    [Route("api/catalogos/iAgua")]
    public class CTIAguaController : ControllerBase
    {
        private readonly ICTIAguaQueryService _incidencias;

        public CTIAguaController(ICTIAguaQueryService incidencias)
        {
            _incidencias = incidencias;
        }

        public async Task<List<CTIAguaDto>> GetAllCTIncidencias()
        {
            var incidencias = await _incidencias.GetAllCTIncidencias();
            return incidencias;
        }

        [HttpGet]
        [Route("getIncidenciasByTipo/{incidencia}")]
        public async Task<List<CTIAguaDto>> GetTiposByIncidenciaId(int incidencia)
        {
            var incidencias = await _incidencias.GetTiposByIncidenciaId(incidencia);

            return incidencias;
        }
        
        [HttpGet]
        [Route("getIncidenciaById/{id}")]
        public async Task<CTIAguaDto> GetIncidenciaById(int id)
        {
            var incidencias = await _incidencias.GetIncidenciaById(id);

            return incidencias;
        }
    }
}
