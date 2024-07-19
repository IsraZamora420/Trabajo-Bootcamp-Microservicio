namespace Trabajo_Bootcamp_Microservicio.Dtos
{
    internal class EmpresaDto
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string Nombre { get; set; }
        public string Razon { get; set; }
        public string DireccionMatriz { get; set; }
        public string TelefonoMatriz { get; set; }
        public string Ciudad { get; set; }
        public short? Estado { get; set; }
    }
}