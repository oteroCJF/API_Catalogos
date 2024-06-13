using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTServicios;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTServicios
{
    public interface ICTServicioQueryService
    {
        Task<List<CTServicioDto>> GetAllServiciosAsync();
        Task<CTServicioDto> GetServicioByIdAsync(int servicio);
    }

    public class CTServicioQueryService : ICTServicioQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTServicioQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTServicioDto>> GetAllServiciosAsync()
        {
            try
            {
                var collection = await _context.Servicios.Where(x => !x.ServicioBasico).OrderBy(x => x.Id).ToListAsync();
                return collection.MapTo<List<CTServicioDto>>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public async Task<CTServicioDto> GetServicioByIdAsync(int servicio)
        {
            try
            {
                return (await _context.Servicios.SingleAsync(x => x.Id == servicio)).MapTo<CTServicioDto>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
