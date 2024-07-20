using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class PuntoVentaService : IPuntoVenta
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public PuntoVentaService(BaseErpContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> GetPuntoEmisionSRI(int PuntoEmisionId, string? PuntoEmision, int? EmpresaId, int? SucursalId, string? CodEstablecimientoSri)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta> GetPuntoVenta(int PuntovtaId, string? PuntovtaNombre, int? PuntoEmisionId)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta> PostPuntoEmisionSRI(PuntoEmisionSri puntoSRI)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta> PostPuntoVenta(PuntoVentum puntoVenta)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta> PutPuntoEmisionSRI(PuntoEmisionSri puntoSRI)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta> PutPuntoVenta(PuntoVentum puntoVenta)
        {
            throw new NotImplementedException();
        }
    }
}
