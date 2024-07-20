using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class CiudadServices : ICiudad
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();
        public CiudadServices(BaseErpContext context)
        {
            this._context = context;
        }
        //-----------------------------------------------CIUDAD--------------------------------------
        public async Task<Respuesta> GetCiudad(int ciudadId, string? nombreCiudad, int paisId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<CiudadDto> query = (from p in _context.Ciudads
                                                  join c in _context.Pais on p.PaisId equals c.PaisId
                                                  select new CiudadDto
                                                  {
                                                      CiudadId = p.CiudadId,
                                                      CiudadNombre = p.CiudadNombre,
                                                      Estado = p.Estado,
                                                      FechaHoraReg = p.FechaHoraReg,
                                                      FechaHoraAct = p.FechaHoraAct,
                                                      UsuIdAct = p.UsuIdAct,
                                                      UsuIdReg = p.UsuIdReg,
                                                      PaisId = p.PaisId,
                                                      PaisNombre = c.PaisNombre
                                                  });
                if (ciudadId != 0)
                {

                    if (ciudadId == 0 && nombreCiudad == null && paisId == 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1"));
                    }
                    else if (ciudadId != 0 && nombreCiudad == null && paisId == 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.CiudadId.Equals(ciudadId));
                    }
                    else if (ciudadId == 0 && nombreCiudad != null && paisId == 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.CiudadNombre.Equals(nombreCiudad));
                    }
                    else if (ciudadId == 0 && nombreCiudad != null && paisId != 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.CiudadNombre.Equals(nombreCiudad) && p.PaisId == paisId);
                    }
                    else if (ciudadId == 0 && nombreCiudad == null && paisId != 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.PaisId == paisId);
                    }
                    else if (ciudadId != 0 && nombreCiudad != null && paisId != 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.CiudadId.Equals(ciudadId) && p.CiudadNombre.Equals(nombreCiudad) && p.PaisId == paisId);
                    }

                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CiudadService", "GetCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostCiudad(Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ciudads.OrderByDescending(c => c.CiudadId).Select(c => c.CiudadId).FirstOrDefault();

                ciudad.CiudadId = Convert.ToInt32(query) + 1;
                ciudad.FechaHoraReg = DateTime.Now;

                _context.Ciudads.Add(ciudad);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CiudadService", "PostCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCiudad(Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Ciudads.Update(ciudad);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CiudadService", "PutCiudad", ee.Message);
            }
            return respuesta;
        }

        //-------------------------------------------------------------------------------------

    }
}
