using Catalogos.Domain.CTEntregables;
using Catalogos.Domain.CTIncidencias;
using Catalogos.Domain.CTServicios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTIncidenciaConfiguration
    {
        public CTIncidenciaConfiguration(EntityTypeBuilder<CTIncidencia> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
