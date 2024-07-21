using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class MovimientoCabDto
    {
        public int MovicabId { get; set; }

        public int? TipomovId { get; set; }
        public string? TipomovNombre { get; set; }

        public int? TipomovIngEgr { get; set; }

        public int? EmpresaId { get; set; }
        public string? EmpresaNombre { get; set; }

        public int? SucursalId { get; set; }
        public string? SucursalNombre { get; set; }

        public int? BodegaId { get; set; }
        public string? BodegaNombre { get; set; }

        public string? SecuenciaFactura { get; set; }

        public string? AutorizacionSri { get; set; }

        public string? ClaveAcceso { get; set; }

        public int? ClienteId { get; set; }
        public string? ClienteNombre { get; set; }

        public int? PuntovtaId { get; set; }
        public string? PuntovtaNombre { get; set; }

        public int? ProveedorId { get; set; }
        public string? ProveedorNombre { get; set; }

        public string? Estado { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }
        public string? UsuIdNombreReg { get; set; }

        public int? UsuIdAct { get; set; }
    }
}
