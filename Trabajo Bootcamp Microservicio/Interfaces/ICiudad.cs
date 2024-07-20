using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface ICiudad
    {
        Task<Respuesta> GetCiudad(int ciudadId, string? nombreCiudad, int paisId);
        Task<Respuesta> PostCiudad(Ciudad ciudad);
        Task<Respuesta> PutCiudad(Ciudad ciudad);
    }
}
