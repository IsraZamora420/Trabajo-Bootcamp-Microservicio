using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IOpcion
    {
        Task<Respuesta> GetOpcion(int opcionId);
        Task<Respuesta> PostOpcion(Opcion opcion);
        Task<Respuesta> PutOpcion(Opcion opcion);
    }
}
