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
    public interface ICTIAguaQueryService
    {
        Task<List<CTIAguaDto>> GetAllCTIncidencias();
        Task<List<CTIAguaDto>> GetTiposByIncidenciaId(int incidencia);
        Task<CTIAguaDto> GetIncidenciaById(int id);
    }

    public class CTIAguaQueryService : ICTIAguaQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTIAguaQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CTIAguaDto>> GetAllCTIncidencias()
        {
            var incidencias = await _context.CTIAgua.ToListAsync();

            return incidencias.MapTo<List<CTIAguaDto>>();
        }

        public async Task<List<CTIAguaDto>> GetTiposByIncidenciaId(int incidencia)
        {
            var incidencias = await _context.CTIAgua.Where(i => i.IncidenciaId == incidencia).ToListAsync();

            return incidencias.MapTo<List<CTIAguaDto>>();
        }

        public async Task<CTIAguaDto> GetIncidenciaById(int id)
        {
            var incidencias = _context.CTIAgua.Single(i => i.Id == id);

            return incidencias.MapTo<CTIAguaDto>();
        }

    }
}
