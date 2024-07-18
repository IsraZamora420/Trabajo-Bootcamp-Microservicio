using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IPais
    {
        Task<Respuesta> GetPais();

        Task<Respuesta> PostPais(Pai pais);    
        Task<Respuesta> PutPais(Pai pais);    
    }
}
