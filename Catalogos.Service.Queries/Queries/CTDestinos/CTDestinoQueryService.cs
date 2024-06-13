using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTDestinos;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTActividadesContratos
{
    public interface ICTDestinoQueryService
    {
        Task<List<CTDestinoDto>> GetAllDestinosAsync();
        Task<CTDestinoDto> GetDestinoById(int id);
    }

    public class CTDestinoQueryService : ICTDestinoQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTDestinoQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTDestinoDto>> GetAllDestinosAsync()
        {
            var partidas = await _context.CTActividadesContratos.ToListAsync();

            return partidas.MapTo<List<CTDestinoDto>>();
        }

        public async Task<CTDestinoDto> GetDestinoById(int id)
        {
            var partidas = await _context.CTActividadesContratos.SingleOrDefaultAsync(p => p.Id == id);

            return partidas.MapTo<CTDestinoDto>();
        }
    }
}
