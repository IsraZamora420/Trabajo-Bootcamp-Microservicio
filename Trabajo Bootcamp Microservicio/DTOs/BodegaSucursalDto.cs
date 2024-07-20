namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    internal class BodegaSucursalDto
    {
        public int BodegaId { get; set; }
        public string BodegaNombre { get; set; }
        public string BodegaDireccion { get; set; }
        public string BodegaTelefono { get; set; }
        public short? Estado { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int SucursalId { get; set; }
        public string SucursalNombre { get; set; }
        public string SucursalDireccion { get; set; }
        public string SucursalTelefono { get; set; }
    }
}