using Trabajo_Bootcamp_Microservicio.Models;

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
    }
}
