
namespace Trabajo_Bootcamp_Microservicio.Services
{
    internal class SucursalDto
    {
        public int SucursalId { get; set; }
        public string SucursalNombre { get; set; }
        public string SucursalDireccion { get; set; }
        public string SucursalTelefono { get; set; }
        public short? Estado { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public int? UsuIdReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int? UsuIdAct { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNombre { get; set; }
    }
}