using Catalogos.Domain.CTEntregables;
using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTEntregables;
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
    public interface ICTIncidenciaQueryService
    {
        Task<List<CTIncidenciaDto>> GetAllCTIncidencias();
        Task<List<CTIncidenciaDto>> GetIncidenciasByServicio(int servicio);        
        Task<CTIncidenciaDto> GetIncidenciaById(int incidencia);
        
    }

    public class CTIncidenciaQueryService : ICTIncidenciaQueryService
    {
        private readonly ApplicationDbContext _context; 

        public CTIncidenciaQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTIncidenciaDto>> GetAllCTIncidencias()
        {
            var entregables = await _context.Incidencias.OrderBy(e => e.Id).ToListAsync();
            return entregables.MapTo<List<CTIncidenciaDto>>();
        }
        
        public async Task<List<CTIncidenciaDto>> GetIncidenciasByServicio(int servicio)
        {
            var entregables = await _context.Incidencias.Where(e => e.ServicioId == servicio).ToListAsync();
            
            return entregables.MapTo<List<CTIncidenciaDto>>();
        }
        
        public async Task<CTIncidenciaDto> GetIncidenciaById(int incidencia)
        {
            var entregables = await _context.Incidencias.SingleOrDefaultAsync(e => e.Id == incidencia);
            
            return entregables.MapTo<CTIncidenciaDto>();
        }
    }
}
