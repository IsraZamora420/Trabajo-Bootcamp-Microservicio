using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class SucursalService : ISucursal
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public SucursalService(BaseErpContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> GetSucursal(int SucursalId, string? SucursalRuc, string? SucursalNombre)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta> PostSucursal(Sucursal sucursal)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta> PutSucursal(Sucursal sucursal)
        {
            throw new NotImplementedException();
        }
    }
}
