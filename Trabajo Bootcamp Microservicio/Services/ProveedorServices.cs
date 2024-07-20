using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.DTOs;
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
        public async Task<Respuesta> GetProveedor(int provId, string? nombreProveedor, string identificacion)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
               // var _query = _context.Proveedors;
                IQueryable<ProveedorDto> query = (from p in _context.Proveedors
                                                 join c in _context.Ciudads on p.CiudadId equals c.CiudadId
                                                 select new ProveedorDto
                                                 {
                                                     ProvId = p.ProvId,
                                                     ProvRuc = p.ProvRuc,
                                                     ProvNomComercial = p.ProvNomComercial,
                                                     ProvRazon = p.ProvRazon,
                                                     ProvDireccion = p.ProvDireccion,
                                                     ProvTelefono = p.ProvTelefono,
                                                     CiudadId = p.CiudadId,
                                                     CiudadNombre = c.CiudadNombre,
                                                     Estado = p.Estado,
                                                     FechaHoraReg = p.FechaHoraReg,
                                                     FechaHoraAct = p.FechaHoraAct,
                                                     UsuIdAct = p.UsuIdAct,
                                                     UsuIdReg = p.UsuIdReg
                                                     });

                if (provId != 0)
                {

                    if (provId == 0 && nombreProveedor == null && identificacion == null)
                    {
                        query = query.Where(p => p.Estado.Equals("A"));
                    }
                    else if (provId != 0 && nombreProveedor == null && identificacion == null)
                    {
                        query = query.Where(p => p.Estado.Equals("A") && p.ProvId.Equals(provId));
                    }
                    else if (provId == 0 && nombreProveedor != null && identificacion == null)
                    {
                        query = query.Where(p => p.Estado.Equals("A") && p.ProvNomComercial.Equals(nombreProveedor));
                    }
                    else if (provId == 0 && nombreProveedor != null && identificacion != null)
                    {
                        query = query.Where(p => p.Estado.Equals("A") && p.ProvNomComercial.Equals(nombreProveedor) && p.ProvRuc == identificacion);
                    }
                    else if (provId == 0 && nombreProveedor == null && identificacion != null)
                    {
                        query = query.Where(p => p.Estado.Equals("A") && p.ProvRuc == identificacion);
                    }
                    else if (provId != 0 && nombreProveedor != null && identificacion != null)
                    {
                        query = query.Where(p => p.Estado.Equals("A") && p.ProvId.Equals(provId) && p.ProvNomComercial.Equals(nombreProveedor) && p.ProvRuc == identificacion);
                    }

                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ProveedorService", "GetProveedor", ex.Message);
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
