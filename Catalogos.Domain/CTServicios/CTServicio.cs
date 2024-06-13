using System.ComponentModel.DataAnnotations;
using System;

namespace Catalogos.Domain.CTServicios
{
    public class CTServicio
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
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public Nullable<DateTime> FechaEliminacion { get; set; }
    }
}
