using Catalogos.Domain.CTIndemnizaciones;
using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTIndemnizaciones
{
    public interface ICTIndemnizacionQueryService
    {
        Task<List<CTIndemnizacion>> GetAllIndemnizaciones();
        Task<List<CTIndemnizacion>> GetIndemnizacionByIncidencia(int id);
        Task<CTIndemnizacion> GetIndemnizacionById(int id);
    }
    public class CTIndemnizacionQueryService : ICTIndemnizacionQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTIndemnizacionQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTIndemnizacion>> GetAllIndemnizaciones()
        {
            var indemnizaciones = await _context.Indemnizaciones.ToListAsync();

            return indemnizaciones.MapTo<List<CTIndemnizacion>>();
        }

        public async Task<List<CTIndemnizacion>> GetIndemnizacionByIncidencia(int id)
        {
            var incidenciaId = await _context.IncidenciasIndemnizacion.Where(i => i.IncidenciaId == id).Select(i => i.IndemnizacionId).ToListAsync();
            var indemnizaciones = await _context.Indemnizaciones.Where(i => incidenciaId.Contains(i.Id)).ToListAsync();

            return indemnizaciones.MapTo<List<CTIndemnizacion>>();
        }

        public async Task<CTIndemnizacion> GetIndemnizacionById(int id)
        {
            var indemnizaciones = await _context.Indemnizaciones.SingleAsync(i => i.Id == id);

            return indemnizaciones.MapTo<CTIndemnizacion>();
        }
    }
}
