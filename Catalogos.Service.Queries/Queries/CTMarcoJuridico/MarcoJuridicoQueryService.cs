using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTMarcoJuridico;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTMarcoJuridico
{
    public interface IMarcoJuridicoQueryService
    {
        Task<List<MarcoJuridicoDto>> GetAllMarcoJuridico();
        Task<MarcoJuridicoDto> GetMarcoJuridicoById(int id);
    }

    public class MarcoJuridicoQueryService : IMarcoJuridicoQueryService
    {
        private readonly ApplicationDbContext _context;

        public MarcoJuridicoQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MarcoJuridicoDto>> GetAllMarcoJuridico()
        {
            var marco = await _context.MarcoJuridico.ToListAsync();
            return marco.MapTo<List<MarcoJuridicoDto>>();
        }

        public async Task<MarcoJuridicoDto> GetMarcoJuridicoById(int id)
        {
            var marco = await _context.MarcoJuridico.SingleOrDefaultAsync(m => m.Id == id);
            return marco.MapTo<MarcoJuridicoDto>();
        }
    }
}
