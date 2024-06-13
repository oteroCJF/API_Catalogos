using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTIncidencias;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTIncidencias
{
    public interface ICTILimpiezaQueryService
    {
        Task<List<CTILimpiezaDto>> GetAllCTIncidencias();
        Task<List<CTILimpiezaDto>> GetTiposByIncidenciaId(int incidencia);
        Task<List<CTILimpiezaDto>> GetNombresByTipo(string tipo);
        Task<CTILimpiezaDto> GetIncidenciaById(int id);
    }

    public class CTILimpiezaQueryService : ICTILimpiezaQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTILimpiezaQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTILimpiezaDto>> GetAllCTIncidencias()
        {
            var incidencias = await _context.CTILimpieza.ToListAsync();

            return incidencias.MapTo<List<CTILimpiezaDto>>();
        }

        public async Task<List<CTILimpiezaDto>> GetTiposByIncidenciaId(int incidencia)
        {
            var incidencias = await _context.CTILimpieza.Where(i => i.IncidenciaId == incidencia).ToListAsync();

            return incidencias.MapTo<List<CTILimpiezaDto>>();
        }
        
        public async Task<List<CTILimpiezaDto>> GetNombresByTipo(string tipo)
        {
            var incidencias = await _context.CTILimpieza.Where(i => i.Tipo.Equals(tipo)).ToListAsync();

            return incidencias.MapTo<List<CTILimpiezaDto>>();
        }
        
        public async Task<CTILimpiezaDto> GetIncidenciaById(int id)
        {
            var incidencias = _context.CTILimpieza.Single(i => i.Id == id);

            return incidencias.MapTo<CTILimpiezaDto>();
        }
    }
}
