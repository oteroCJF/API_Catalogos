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
    [Route("api/catalogos/icomedor")]
    public class CTIComedorController : ControllerBase
    {
        private readonly ICTIComedorQueryService _incidencias;

        public CTIComedorController(ICTIComedorQueryService incidencias)
        {
            _incidencias = incidencias;
        }

        public async Task<List<CTIComedorDto>> GetAllCTIncidencias()
        {
            var incidencias = await _incidencias.GetAllCTIncidencias();
            return incidencias;
        }

        [HttpGet]
        [Route("getIncidenciasByTipo/{incidencia}")]
        public async Task<List<CTIComedorDto>> GetTiposByIncidenciaId(int incidencia)
        {
            var incidencias = await _incidencias.GetTiposByIncidenciaId(incidencia);

            return incidencias;
        }
        
        [HttpGet]
        [Route("getNombresByTipo/{tipo}")]
        public async Task<List<CTIComedorDto>> GetNombresByTipo(int tipo)
        {
            var incidencias = await _incidencias.GetNombresByTipo(tipo);

            return incidencias;
        }
        
        [HttpGet]
        [Route("getIncidenciaById/{id}")]
        public async Task<CTIComedorDto> GetIncidenciaById(int id)
        {
            var incidencias = await _incidencias.GetIncidenciaById(id);

            return incidencias;
        }
    }
}
