﻿using Catalogos.Service.Queries.DTOs.CTIncidencias;
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
    [Route("api/catalogos/iFumigacion")]
    public class CTIFumigacionController : ControllerBase
    {
        private readonly ICTIFumigacionQueryService _incidencias;

        public CTIFumigacionController(ICTIFumigacionQueryService incidencias)
        {
            _incidencias = incidencias;
        }

        public async Task<List<CTIFumigacionDto>> GetAllCTIncidencias()
        {
            var incidencias = await _incidencias.GetAllCTIncidencias();
            return incidencias;
        }

        [HttpGet]
        [Route("getIncidenciasByTipo/{incidencia}")]
        public async Task<List<CTIFumigacionDto>> GetTiposByIncidenciaId(int incidencia)
        {
            var incidencias = await _incidencias.GetTiposByIncidenciaId(incidencia);

            return incidencias;
        }
        
        [HttpGet]
        [Route("getNombresByTipo/{tipo}")]
        public async Task<List<CTIFumigacionDto>> GetNombresByTipo(string tipo)
        {
            var incidencias = await _incidencias.GetNombresByTipo(tipo);

            return incidencias;
        }
        
        [HttpGet]
        [Route("getIncidenciaById/{id}")]
        public async Task<CTIFumigacionDto> GetIncidenciaById(int id)
        {
            var incidencias = await _incidencias.GetIncidenciaById(id);

            return incidencias;
        }
    }
}
