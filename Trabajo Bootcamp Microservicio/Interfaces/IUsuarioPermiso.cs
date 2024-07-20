using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IUsuarioPermiso
    {
        Task<Respuesta> GetUsuarioPermiso(int PermisoId);
        Task<Respuesta> PostUsuarioPermiso(UsuarioPermiso usuarioPermiso);
        Task<Respuesta> PutUsuarioPermiso(UsuarioPermiso usuarioPermiso);
    }
}
