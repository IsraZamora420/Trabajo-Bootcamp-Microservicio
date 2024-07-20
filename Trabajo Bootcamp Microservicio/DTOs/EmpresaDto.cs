namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    internal class EmpresaDto
    {
        public int EmpresaId { get; set; }
        public string Ruc { get; set; }
        public string Nombre { get; set; }
        public string Razon { get; set; }
        public string DireccionMatriz { get; set; }
        public string TelefonoMatriz { get; set; }
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public short? Estado { get; set; }
    }
}