using Catalogos.Service.Queries.DTOs.CTParametros;
using Catalogos.Service.Queries.Queries.CTParametros;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTParametros
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/parametros")]
    public class CTParametroController : ControllerBase
    {
        private readonly ICTParametroQueryService _servicios;

        public CTParametroController(ICTParametroQueryService servicios)
        {
            _servicios = servicios;
        }

        [HttpGet]
        public async Task<List<CTParametroDto>> GetAllServiciosAsync()
        {
            return await _servicios.GetAllParametrosAsync();
        }

        [Route("getParametroById/{parametro}")]
        [HttpGet]
        public async Task<CTParametroDto> GetParametroByIdAsync(int parametro)
        {
            return await _servicios.GetParametroByIdAsync(parametro);
        }
        
        [Route("getParametroByTipo/{tipo}")]
        [HttpGet]
        public async Task<List<CTParametroDto>> GetParametroByTipoAsync(string tipo)
        {
            return await _servicios.GetParametroByTipoAsync(tipo);
        }
        
        [Route("getParametroByTabla/{tabla}")]
        [HttpGet]
        public async Task<List<CTParametroDto>> GetParametroByTablaAsync(string tabla)
        {
            return await _servicios.GetParametroByTablaAsync(tabla);
        }
    }
}
