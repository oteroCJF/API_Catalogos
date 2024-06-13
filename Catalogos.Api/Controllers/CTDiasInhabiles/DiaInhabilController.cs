using Catalogos.Service.Queries.DTOs.CTDiasInhabiles;
using Catalogos.Service.Queries.Queries.CTDiasInhabiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTDiasInhabiles
{

    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/diasinhabiles")]
    public class DiaInhabilController : ControllerBase
    {
        private readonly IDiaInhabilQueryService _dias;

        public DiaInhabilController(IDiaInhabilQueryService dias)
        {
            _dias = dias;
        }

        public async Task<List<DiaInhabilDto>> GetAllDiasInhabiles(int anio)
        {
            var entregables = await _dias.GetAllDiasInhabiles();
            return entregables;
        }

        [HttpGet]
        [Route("getDiasInhabilesByAnio/{anio}")]
        public async Task<List<DiaInhabilDto>> GetDiasInhabilesByAnio(int anio)
        {
            var entregables = await _dias.GetDiasByAnio(anio);
            return entregables;
        }


        [HttpGet]
        [Route("esdiaInhabil/{anio}/{fecha}")]
        public async Task<bool> EsDiaInhabil(int anio, string fecha)
        {
            var esInhabil = await _dias.EsDiaInhabil(anio, Convert.ToDateTime(fecha));

            return esInhabil;
        }

    }
}
