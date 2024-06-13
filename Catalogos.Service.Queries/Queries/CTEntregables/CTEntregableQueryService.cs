using Catalogos.Domain.CTEntregables;
using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTEntregables;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTEntregables
{
    public interface ICTEntregableQueryService
    {
        Task<List<CTEntregableDto>> GetAllCTEntregables();
        Task<List<EntregableServicioDto>> GetEntregablesServicio(int servicio);
        Task<CTEntregableDto> GetEntregableById(int entregable);
    }

    public class CTEntregableQueryService : ICTEntregableQueryService
    {
        private readonly ApplicationDbContext _context; 

        public CTEntregableQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTEntregableDto>> GetAllCTEntregables()
        {
            var entregables = await _context.Entregables.OrderBy(e => e.Id).OrderBy(e => e.Orden).ToListAsync();
            return entregables.MapTo<List<CTEntregableDto>>();
        }
        
        public async Task<List<EntregableServicioDto>> GetEntregablesServicio(int servicio)
        {
            var entregables = await _context.EntregableServicio.Where(e => e.ServicioId == servicio).ToListAsync();
            
            return entregables.MapTo<List<EntregableServicioDto>>();
        }
        
        public async Task<CTEntregableDto> GetEntregableById(int entregable)
        {
            var entregables = await _context.Entregables.SingleOrDefaultAsync(e => e.Id == entregable);
            
            return entregables.MapTo<CTEntregableDto>();
        }
    }
}
