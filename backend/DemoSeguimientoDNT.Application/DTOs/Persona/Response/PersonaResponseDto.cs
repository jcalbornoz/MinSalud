namespace DemoSeguimientoDNT.Application.DTOs.Persona.Response
{
    public class PersonaResponseDto
    {
        public int? IdPersona { get; set; }

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
