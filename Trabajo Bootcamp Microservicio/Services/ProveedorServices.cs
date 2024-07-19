using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class ProveedorServices: IProveedor
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();
        public ProveedorServices(BaseErpContext context)
        {
            this._context  = context;
        }
        //-----------------------------------------------PROVEEDOR--------------------------------------
        public async Task<Respuesta> GetProveedor()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Proveedors.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "GetProveedor", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostProveedor(Proveedor proveedor)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Proveedors.OrderByDescending(c => c.ProvId).Select(c => c.ProvId).FirstOrDefault();

                proveedor.ProvId = Convert.ToInt32(query) + 1;
                proveedor.FechaHoraReg = DateTime.Now;

                _context.Proveedors.Add(proveedor);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PostProveedor", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutProveedor(Proveedor proveedor)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Proveedors.Update(proveedor);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PutProveedor", ee.Message);
            }
            return respuesta;
        }

        //-------------------------------------------------------------------------------------

    }
}
