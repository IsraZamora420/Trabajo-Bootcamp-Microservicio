using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class UsuarioRolDto
    {
        public int UsuRolId { get; set; }
        public int? UsuId { get; set; }
        public string? UsuNombre { get; set; }
        public int? RolId { get; set; }
        public string? RolDescripcion { get; set; }
        public short? Estado { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int? UsuIdReg { get; set; }
        public int? UsuIdAct { get; set; }

     }
}
