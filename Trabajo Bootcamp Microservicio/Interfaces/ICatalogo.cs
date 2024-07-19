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
        
    }
}
