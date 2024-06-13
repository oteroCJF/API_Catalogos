using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Domain.CTIncidencias
{
    public class CTIncidencia
    {
        public int Id { get; set; }
        public int ServicioId { get; set; }
        public string Abreviacion { get; set; }
        public string Valor { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
