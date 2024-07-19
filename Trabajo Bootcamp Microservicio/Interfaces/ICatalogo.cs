using System.Text.RegularExpressions;
using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface ICatalogo
    {
        //-----------------------ROL----------------
        Task<Respuesta> GetRol();
        Task<Respuesta> PostRol(Rol rol);
        Task<Respuesta> PutRol(Rol rol);
        //---------------------------------------------
        /*
        Task<Respuesta> GetProveedor();
        Task<Respuesta> PostProveedor(Proveedor proveedor);
        Task<Respuesta> PutProveedor(Proveedor proveedor);
        */
        //-----------------------TIPO MOVIMIENTO----------------
        Task<Respuesta> GetTipoMovimiento();
        Task<Respuesta> PostTipoMovimiento(TipoMovimiento tipoMovimiento);
        Task<Respuesta> PutTipoMovimiento(TipoMovimiento tipoMovimiento);
        //---------------------------------------------

        //-----------------------USUARIO----------------
        Task<Respuesta> GetUsuario();
        Task<Respuesta> PostUsuario(Usuario usuario);
        Task<Respuesta> PutUsuario(Usuario usuario);
        //---------------------------------------------

        //-----------------------PAIS----------------
        Task<Respuesta> GetPais(int idpais);
        Task<Respuesta> PostPais(Pai pais);
        Task<Respuesta> PutPais(Pai pais);
        //---------------------------------------------
    }
}
