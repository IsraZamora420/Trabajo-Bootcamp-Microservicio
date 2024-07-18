using System.Text.RegularExpressions;
using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> GetRol();
        //Task<Respuesta> PostRol(Rol rol);
        //Task<Respuesta> PutRol(Rol rol);
    }
}
