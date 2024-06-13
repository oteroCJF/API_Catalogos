using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Domain.CTServiciosContratos
{
    public class CTServicioContrato
    {
        public int Id { get; set; }
        public int ServicioId { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
