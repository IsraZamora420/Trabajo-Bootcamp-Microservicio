namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class JsonLogDto
    {
        //---------PRODUCTO-----------------
        public int idProducto { get; set; }
        //--------USUARIO AUTENTICACION----
        public string user { get; set; }
        public string password { get; set; }
        //--------PAIS----------------------
        public int idPais { get; set; }
        //--------CATALOGO------------------
        public int idCatalogo { get; set; }
        //---------MOVIMIENTO CAB-----------
        public int idMovCab { get; set; }
        //--------MOVIMIENTO DETALLE PRODUCTO------
        public int idMovDetProd { get; set; }
        //----------CLIENTE-------------------------
        public int idCliente { get; set; }
        //----------EMPRESA-------------------------
        public int idEmpresa { get; set; }
        public string empresaRuc { get; set; }
        public string empresaNombre { get; set; }
    }
}
