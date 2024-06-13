using Catalogos.Service.Queries.DTOs.CTMarcoJuridico;
using Catalogos.Service.Queries.Queries.CTMarcoJuridico;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalogos.Api.Controllers.CTMarcoJuridico
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/catalogos/marcoJuridico")]
    public class MarcoJuridicoController : ControllerBase
    {
        private readonly IMarcoJuridicoQueryService _marco;
        private readonly IHostingEnvironment _environment;

        public MarcoJuridicoController(IMarcoJuridicoQueryService marco, IHostingEnvironment environment)
        {
            _marco = marco;
            _environment = environment;
        }

        [HttpGet]
        public async Task<List<MarcoJuridicoDto>> GetAllServiciosAsync()
        {
            return await _marco.GetAllMarcoJuridico();
        }

        [Route("getMarcoJuridicoById/{id}")]
        [HttpGet]
        public async Task<MarcoJuridicoDto> GetParametroByIdAsync(int id)
        {
            return await _marco.GetMarcoJuridicoById(id);
        }

        [Route("visualizarEntregable/{archivo}")]
        [HttpGet]
        public async Task<string> VisualizarEntregable(string archivo)
        {
            string folderName = Directory.GetCurrentDirectory() + "\\MarcoJuridico\\" + archivo;
            string webRootPath = _environment.ContentRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            string pathArchivo = Path.Combine(newPath, archivo);

            if (System.IO.File.Exists(pathArchivo))
            {
                return pathArchivo;
            }

            return "";
        }

        [Route("getPathEntregables")]
        [HttpGet]
        public async Task<string> GetPathEntregables()
        {
            string folderName = Directory.GetCurrentDirectory() + "\\Entregables";

            return folderName;
        }
    }
}
