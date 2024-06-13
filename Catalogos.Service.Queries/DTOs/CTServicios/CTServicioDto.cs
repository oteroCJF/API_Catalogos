using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Service.Queries.DTOs.CTServicios
{
    public class CTServicioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Folio { get; set; }
        public string Abreviacion { get; set; }
        public string Descripcion { get; set; }
        public string Icono { get; set; }
        public string Fondo { get; set; }
        public string FondoHexadecimal { get; set; }
        public bool ServicioBasico { get; set; }
        public Nullable<DateTime> FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public Nullable<DateTime> FechaEliminacion { get; set; }
    }
}
