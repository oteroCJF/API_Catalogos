using Catalogos.Domain.CTIncidencias;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTILimpiezaConfiguration
    {
        public CTILimpiezaConfiguration(EntityTypeBuilder<CTILimpieza> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
