using Catalogos.Domain.CTEntregables;
using Catalogos.Domain.CTServicios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTServicioConfiguration
    {
        public CTServicioConfiguration(EntityTypeBuilder<CTServicio> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
