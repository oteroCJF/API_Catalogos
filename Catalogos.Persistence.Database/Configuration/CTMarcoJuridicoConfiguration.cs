using Catalogos.Domain.CTEntregables;
using Catalogos.Domain.CTMarcoJuridico;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTMarcoJuridicoConfiguration
    {
        public CTMarcoJuridicoConfiguration(EntityTypeBuilder<MarcoJuridico> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
