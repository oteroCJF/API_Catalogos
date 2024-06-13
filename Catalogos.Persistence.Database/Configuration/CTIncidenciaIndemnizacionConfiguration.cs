using Catalogos.Domain.CTEntregables;
using Catalogos.Domain.CTIndemnizaciones;
using Catalogos.Domain.CTServicios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTIncidenciaIndemnizacionConfiguration
    {
        public CTIncidenciaIndemnizacionConfiguration(EntityTypeBuilder<CTIncidenciaIndemnizacion> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.IncidenciaId, x.IndemnizacionId });
        }
    }
}
