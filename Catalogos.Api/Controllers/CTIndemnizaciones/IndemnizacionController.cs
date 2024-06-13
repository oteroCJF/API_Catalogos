using Catalogos.Service.Queries.Queries.CTIndemnizaciones;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTIndemnizaciones
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/indemnizacion")]
    public class IndemnizacionController : ControllerBase
    {
        private readonly ICTIndemnizacionQueryService _indemnizacion;

        public IndemnizacionController(ICTIndemnizacionQueryService indemnizacion)
        {
            _indemnizacion = indemnizacion;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndemnizaciones()
        {
            var indemnizaciones = await _indemnizacion.GetAllIndemnizaciones();
            
            return Ok(indemnizaciones);
        }
        
        [HttpGet]
        [Route("getIndemnizacionByIncidencia/{incidencia}")]
        public async Task<IActionResult> GetIndemnizacionByIncidencia(int incidencia)
        {
            var indemnizaciones = await _indemnizacion.GetIndemnizacionByIncidencia(incidencia);
            
            return Ok(indemnizaciones);
        }
        
        [HttpGet]
        [Route("getIndemnizacionById/{id}")]
        public async Task<IActionResult> GetIndemnizacionById(int id)
        {
            var indemnizaciones = await _indemnizacion.GetIndemnizacionById(id);
            
            return Ok(indemnizaciones);
        }
    }
}
