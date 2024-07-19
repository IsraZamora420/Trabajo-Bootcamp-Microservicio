using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IEmpresa
    {
        Task<Respuesta> GetEmpresa(int? EmpresaId, string? EmpresaRuc, string? EmpresaNombre);
        Task<Respuesta> PostEmpresa(Empresa empresa);
        Task<Respuesta> PutEmpresa(Empresa empresa);
    }
}
