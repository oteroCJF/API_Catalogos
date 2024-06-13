using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Domain.CTIncidencias
{
    public class CTILimpieza
    {
        public int Id { get; set; }
        public int IncidenciaId { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
    }
}
