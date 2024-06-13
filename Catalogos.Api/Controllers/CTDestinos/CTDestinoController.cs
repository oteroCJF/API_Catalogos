using Catalogos.Service.Queries.DTOs.CTDestinos;
using Catalogos.Service.Queries.Queries.CTActividadesContratos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTActividadesContratos
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/destinos")]
    public class CTDestinoController : ControllerBase
    {
        private readonly ICTDestinoQueryService _destinos;

        public CTDestinoController(ICTDestinoQueryService destinos)
        {
            _destinos = destinos;
        }

        [HttpGet]
        public async Task<List<CTDestinoDto>> GetAllDestinosAsync()
        {
            return await _destinos.GetAllDestinosAsync();
        }

        [Route("getDestinoById/{id}")]
        [HttpGet]
        public async Task<CTDestinoDto> GetDestinoById(int id)
        {
            return await _destinos.GetDestinoById(id);
        }
    }
}
