using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface ICatalogo
    {
        //-----------------------PAIS----------------
        Task<Respuesta> GetPais(int idpais);

        Task<Respuesta> PostPais(Pai pais);
        Task<Respuesta> PutPais(Pai pais);
        //-----------------------------------------------
        //-----------------------CATEGORIA----------------
        Task<Respuesta> PostCategoria(Categorium categoria);
        Task<Respuesta> GetCategoria(int idCategoria);
        Task<Respuesta> PutCategoria(Categorium categoria);
        //-----------------------------------------------
        //-----------------------FORMA DE PAGO----------------
        Task<Respuesta> GetFormaPago(int idPago);
        Task<Respuesta> PostFormaPago(FormaPago formaPago);
        Task<Respuesta> PutFormaPago(FormaPago formaPago);
    }
}
