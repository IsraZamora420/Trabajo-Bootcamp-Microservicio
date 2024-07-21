using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class UsuarioPermisoDto
    {
        public int PermisoId { get; set; }
        public int? ModuloId { get; set; }
        public string? ModuloDescripcion { get; set; }

        public int? OpcionId { get; set; }
        public string? OpcionNombre { get; set; }

        public int? UsuId { get; set; }
        public string? UsuNombre { get; set; }

        public short? EstadoPermiso { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }

        public int? UsuIdAct { get; set; }

    }
}
