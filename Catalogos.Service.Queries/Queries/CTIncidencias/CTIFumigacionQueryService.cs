using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTIncidencias;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTIncidencias
{
    public interface ICTIFumigacionQueryService
    {
        Task<List<CTIFumigacionDto>> GetAllCTIncidencias();
        Task<List<CTIFumigacionDto>> GetTiposByIncidenciaId(int incidencia);
        Task<List<CTIFumigacionDto>> GetNombresByTipo(string tipo);
        Task<CTIFumigacionDto> GetIncidenciaById(int id);
    }

    public class CTIFumigacionQueryService : ICTIFumigacionQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTIFumigacionQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTIFumigacionDto>> GetAllCTIncidencias()
        {
            var incidencias = await _context.CTIFumigacion.ToListAsync();

            return incidencias.MapTo<List<CTIFumigacionDto>>();
        }

        public async Task<List<CTIFumigacionDto>> GetTiposByIncidenciaId(int incidencia)
        {
            var incidencias = await _context.CTIFumigacion.Where(i => i.IncidenciaId == incidencia).ToListAsync();

            return incidencias.MapTo<List<CTIFumigacionDto>>();
        }
        
        public async Task<List<CTIFumigacionDto>> GetNombresByTipo(string tipo)
        {
            var incidencias = await _context.CTIFumigacion.Where(i => i.Tipo.Equals(tipo)).ToListAsync();

            return incidencias.MapTo<List<CTIFumigacionDto>>();
        }
        
        public async Task<CTIFumigacionDto> GetIncidenciaById(int id)
        {
            var incidencias = _context.CTIFumigacion.Single(i => i.Id == id);

            return incidencias.MapTo<CTIFumigacionDto>();
        }
    }
}
