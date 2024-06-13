using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTDiasInhabiles;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTDiasInhabiles
{
    public interface IDiaInhabilQueryService
    {
        Task<List<DiaInhabilDto>> GetAllDiasInhabiles();
        Task<List<DiaInhabilDto>> GetDiasByAnio(int anio);
        Task<bool> EsDiaInhabil(int anio, DateTime fecha);
    }

    public class DiaInhabilQueryService : IDiaInhabilQueryService
    {
        private readonly ApplicationDbContext _context;

        public DiaInhabilQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EsDiaInhabil(int anio, DateTime fecha)
        {
            var inhabil = await _context.CTDiasInhabiles.SingleOrDefaultAsync(d => d.Anio == anio && d.FechaInhabil == fecha);

            return inhabil != null ? true : false;
        }

        public async Task<List<DiaInhabilDto>> GetAllDiasInhabiles()
        {
            var dias = await _context.CTDiasInhabiles.ToListAsync();

            return dias.MapTo<List<DiaInhabilDto>>();
        }

        public async Task<List<DiaInhabilDto>> GetDiasByAnio(int anio)
        {
            var dias = await _context.CTDiasInhabiles.Where(d => d.Anio == anio).ToListAsync();

            return dias.MapTo<List<DiaInhabilDto>>();
        }
    }
}
