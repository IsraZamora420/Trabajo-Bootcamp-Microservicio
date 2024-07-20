using Trabajo_Bootcamp_Microservicio.Models;
using System.Text.RegularExpressions;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface ICatalogo
    {
        //----------------Industria-----------
        Task<Respuesta> GetIndustria(int industriaId);
        Task<Respuesta> PutIndustria( Industrium industria );      
        Task<Respuesta> PostIndustria( Industrium industria );
        //----------------Modulo------------------
        Task<Respuesta> GetModulo(int moduloId);
        Task<Respuesta> PutModulo(Modulo modulo );   
        Task<Respuesta> PostModulo(Modulo modulo );  
        //----------------Cliente-----------------
        Task<Respuesta> GetCliente(int clienteId);
        Task<Respuesta> PutCliente (Cliente cliente);
        Task<Respuesta> PostCliente (Cliente cliente);
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
    }
}
