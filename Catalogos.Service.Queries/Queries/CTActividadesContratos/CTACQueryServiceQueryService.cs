using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTActividadesContratos;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTActividadesContratos
{
    public interface ICTACQueryServiceQueryService
    {
        Task<List<CTActividadContratoDto>> GetAllCTActividadesContratos();
        Task<CTActividadContratoDto> GetActividadById(int id);
    }

    public class CTACQueryServiceQueryService : ICTACQueryServiceQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTACQueryServiceQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTActividadContratoDto>> GetAllCTActividadesContratos()
        {
            var partidas = await _context.CTActividadesContratos.ToListAsync();

            return partidas.MapTo<List<CTActividadContratoDto>>();
        }

        public async Task<CTActividadContratoDto> GetActividadById(int id)
        {
            var partidas = await _context.CTActividadesContratos.SingleOrDefaultAsync(p => p.Id == id);

            return partidas.MapTo<CTActividadContratoDto>();
        }
    }
}
