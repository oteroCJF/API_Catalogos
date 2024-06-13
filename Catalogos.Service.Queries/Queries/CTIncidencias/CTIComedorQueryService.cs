using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTIncidencias;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTIncidencias
{
    public interface ICTIComedorQueryService
    {
        Task<List<CTIComedorDto>> GetAllCTIncidencias();
        Task<List<CTIComedorDto>> GetTiposByIncidenciaId(int incidencia);
        Task<List<CTIComedorDto>> GetNombresByTipo(int tipo);
        Task<CTIComedorDto> GetIncidenciaById(int id);
    }

    public class CTIComedorQueryService : ICTIComedorQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTIComedorQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CTIComedorDto>> GetAllCTIncidencias()
        {
            var incidencias = await _context.CTIComedor.ToListAsync();

            return incidencias.MapTo<List<CTIComedorDto>>();
        }

        public async Task<List<CTIComedorDto>> GetTiposByIncidenciaId(int incidencia)
        {
            var incidencias = await _context.CTIComedor.Where(i => i.IncidenciaId == incidencia).ToListAsync();

            return incidencias.MapTo<List<CTIComedorDto>>();
        }

        public async Task<List<CTIComedorDto>> GetNombresByTipo(int tipo)
        {
            var incidencias = await _context.CTIComedor.Where(i => i.TipoId == tipo).ToListAsync();

            return incidencias.MapTo<List<CTIComedorDto>>();
        }

        public async Task<CTIComedorDto> GetIncidenciaById(int id)
        {
            var incidencias = _context.CTIComedor.Single(i => i.Id == id);

            return incidencias.MapTo<CTIComedorDto>();
        }

    }
}
