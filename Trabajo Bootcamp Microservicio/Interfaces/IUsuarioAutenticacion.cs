using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IUsuarioAutenticacion
    {
        Task<Respuesta> GetUsuarioAutenticacion(string? usuario, string? contrasenia);

    }
}
