using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeguimientoDNT.Application.DTOs.Persona.Request
{
    public class PersonaRequestDto
    {
        public string? TipoIdentificacion { get; set; } = null!;

        public string? NroIdentificacion { get; set; } = null!;

        public string? PrimerNombre { get; set; } = null!;

        public string? SegundoNombre { get; set; }

        public string? PrimerApellido { get; set; } = null!;

        public string? SegundoApellido { get; set; }

        public string? Sexo { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public string? CodMpioResidencia { get; set; } = null!;

        public string? CodAsegurador { get; set; } = null!;
    }
}
