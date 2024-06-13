using Catalogos.Domain.CTEntregables;
using Catalogos.Domain.CTIndemnizaciones;
using Catalogos.Domain.CTServicios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTIndemnizacionConfiguration
    {
        public CTIndemnizacionConfiguration(EntityTypeBuilder<CTIndemnizacion> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
