using Catalogos.Domain.CTDestinos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTDestinosConfiguration
    {
        public CTDestinosConfiguration(EntityTypeBuilder<CTDestino> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
