namespace DemoSeguimientoDNT.Domain.Entities;

public partial class Seguimiento : BaseEntity
{
    public int? IdPersona { get; set; }

    public int? EstadoVital { get; set; }

    public DateTime? FechaDefuncion { get; set; } = null!;

    public int? UbicacionDefuncion { get; set; }

    public string? CodLugarAtencion { get; set; } = null!;

    public DateTime? FechaAtencion { get; set; }

    public decimal? PesoKg { get; set; }

    public short? TallaCm { get; set; }

    public string? CodClasificacionNutricional { get; set; } = null!;

    public string? CodManejoActual { get; set; } = null!;

    public string? DesManejo { get; set; } = null!;

    public string? CodUbicacion { get; set; } = null!;

    public string? DesUbicacion { get; set; } = null!;

    public string? CodTratamiento { get; set; } = null!;

    public short? TotalSobresFtlc { get; set; }

    public string? OtroTratamiento { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
