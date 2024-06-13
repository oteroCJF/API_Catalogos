using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTParametros;
using Catalogos.Service.Queries.DTOs.CTServicios;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTParametros
{
    public interface ICTParametroQueryService
    {
        Task<List<CTParametroDto>> GetAllParametrosAsync();
        Task<CTParametroDto> GetParametroByIdAsync(int parametro);
        Task<List<CTParametroDto>> GetParametroByTipoAsync(string tipo);
        Task<List<CTParametroDto>> GetParametroByTablaAsync(string tabla);
    }

    public class CTParametroQueryService : ICTParametroQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTParametroQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTParametroDto>> GetAllParametrosAsync()
        {
            try
            {
                var collection = await _context.Parametros.OrderBy(x => x.Id).ToListAsync();
                return collection.MapTo<List<CTParametroDto>>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public async Task<CTParametroDto> GetParametroByIdAsync(int parametro)
        {
            try
            {
                return (await _context.Parametros.SingleAsync(x => x.Id == parametro)).MapTo<CTParametroDto>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public async Task<List<CTParametroDto>> GetParametroByTipoAsync(string tipo)
        {
            try
            {
                var parametros = await _context.Parametros.Where(x => x.Tipo.Equals(tipo)).ToListAsync();
                return parametros.MapTo<List<CTParametroDto>>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public async Task<List<CTParametroDto>> GetParametroByTablaAsync(string tabla)
        {
            try
            {
                var parametros = await _context.Parametros.Where(x => x.Tabla.Equals(tabla)).ToListAsync();
                return parametros.MapTo<List<CTParametroDto>>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
