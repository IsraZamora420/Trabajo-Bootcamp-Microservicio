using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IUsuarioRol
    {
        Task<Respuesta> GetUsuarioRol(int usurolId, int usulId, int rolId);
        Task<Respuesta> PostUsuarioRol(UsuarioRol usuariorol);
        Task<Respuesta> PutUsuarioRol(UsuarioRol usuariorol);
    }
}
