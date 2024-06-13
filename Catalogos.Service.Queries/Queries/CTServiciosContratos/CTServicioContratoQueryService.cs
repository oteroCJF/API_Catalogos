using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.DTOs.CTServicios;
using Catalogos.Service.Queries.DTOs.CTServiciosContratos;
using Catalogos.Service.Queries.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Service.Queries.Queries.CTServiciosContratos
{
    public interface ICTServicioContratoQueryService
    {
        Task<List<CTServicioContratoDto>> GetAllServiciosContratoAsync();
        Task<List<CTServicioContratoDto>> GetServiciosByServicio(int servicio);
        Task<CTServicioContratoDto> GetServicioContratoById(int servicio);
    }

    public class CTServicioContratoQueryService : ICTServicioContratoQueryService
    {
        private readonly ApplicationDbContext _context;

        public CTServicioContratoQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CTServicioContratoDto>> GetAllServiciosContratoAsync()
        {
            try
            {
                var collection = await _context.ServiciosContratos.OrderBy(x => x.Id).ToListAsync();
                return collection.MapTo<List<CTServicioContratoDto>>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public async Task<List<CTServicioContratoDto>> GetServiciosByServicio(int servicio)
        {
            try
            {
                var servicios = await _context.ServiciosContratos.Where(x => x.ServicioId == servicio).ToListAsync();
                return  servicios.MapTo<List<CTServicioContratoDto>>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        
        public async Task<CTServicioContratoDto> GetServicioContratoById(int servicio)
        {
            try
            {
                var servicios = await _context.ServiciosContratos.SingleOrDefaultAsync(x => x.Id == servicio);
                return servicios.MapTo<CTServicioContratoDto>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
