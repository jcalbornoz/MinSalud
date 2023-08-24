using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeguimientoDNT.Domain.Entities
{
    public class Reporte : BaseEntity
    {
        public int? IdPersona { get; set; }
        public string? TipoIdentificacion { get; set; }
        public string? NroIdentificacion { get; set; }
        public string? NombresApellidos { get; set; }
        public string? Upgd { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public string? Asegurador { get; set; }
        public DateTime? FechaDefunsion { get; set; }
        public DateTime? UltimoSeguimiento { get; set; }
    }
}
