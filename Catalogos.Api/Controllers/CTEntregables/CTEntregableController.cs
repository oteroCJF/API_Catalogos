using Catalogos.Service.Queries.DTOs.CTEntregables;
using Catalogos.Service.Queries.Queries.CTEntregables;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTEntregables
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/entregables")]
    public class CTEntregableController : ControllerBase
    {
        private readonly ICTEntregableQueryService _entregables;

        public CTEntregableController(ICTEntregableQueryService entregables)
        {
            _entregables = entregables;
        }

        public async Task<List<CTEntregableDto>> GetAllEntregables()
        {
            var entregables = await _entregables.GetAllCTEntregables();
            return entregables;
        }

        
        [HttpGet]
        [Route("getEntregablesByServicio/{servicio}")]
        public async Task<List<EntregableServicioDto>> GetEntregablesServicio(int servicio)
        {
            var entregables = await _entregables.GetEntregablesServicio(servicio);
            return entregables;
        }


        [HttpGet]
        [Route("getEntregableById/{entregable}")]
        public async Task<CTEntregableDto> GetEntregableById(int entregable)
        {
            var entregables = await _entregables.GetEntregableById(entregable);

            return entregables;
        }
    }
}
