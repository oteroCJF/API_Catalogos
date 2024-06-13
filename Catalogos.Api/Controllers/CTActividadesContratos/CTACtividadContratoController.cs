
using Catalogos.Service.Queries.DTOs.CTActividadesContratos;
using Catalogos.Service.Queries.DTOs.CTServicios;
using Catalogos.Service.Queries.Queries.CTActividadesContratos;
using Catalogos.Service.Queries.Queries.CTServicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTActividadesContratos
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/actividades")]
    public class CTActividadesContratosController : ControllerBase
    {
        private readonly ICTACQueryServiceQueryService _partidasbm;

        public CTActividadesContratosController(ICTACQueryServiceQueryService partidasbm)
        {
            _partidasbm = partidasbm;
        }

        [HttpGet]
        public async Task<List<CTActividadContratoDto>> GetAllActividadesAsync()
        {
            return await _partidasbm.GetAllCTActividadesContratos();
        }

        [Route("getActividadById/{id}")]
        [HttpGet]
        public async Task<CTActividadContratoDto> GetActividadByIdAsync(int id)
        {
            return await _partidasbm.GetActividadById(id);
        }
    }
}
