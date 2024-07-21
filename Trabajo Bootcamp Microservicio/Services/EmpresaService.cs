using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class EmpresaService : IEmpresa
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public EmpresaService(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetEmpresa(int? EmpresaId, string? EmpresaRuc, string? EmpresaNombre)
        {
            var respuesta = new Respuesta();
            try
            {
                if (EmpresaId != 0 && EmpresaRuc != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from e in _context.Empresas
                                            join c in _context.Ciudads on e.CiudadId equals c.CiudadId
                                            where e.Estado.Value == 1 && e.EmpresaId.Equals(EmpresaId) && e.EmpresaRuc.Equals(EmpresaRuc)
                                            select new EmpresaDto
                                            {
                                                EmpresaId = e.EmpresaId,
                                                Ruc = e.EmpresaRuc,
                                                Nombre = e.EmpresaNombre,
                                                Razon = e.EmpresaRazon,
                                                DireccionMatriz = e.EmpresaDireccionMatriz,
                                                TelefonoMatriz = e.EmpresaTelefonoMatriz,
                                                IdCiudad = c.CiudadId,
                                                Ciudad = c.CiudadNombre,
                                                Estado = e.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (EmpresaId != 0 && EmpresaNombre.IsNullOrEmpty() && EmpresaRuc.IsNullOrEmpty())
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from e in _context.Empresas
                                            join c in _context.Ciudads on e.CiudadId equals c.CiudadId
                                            where e.Estado.Value == 1 && e.EmpresaId.Equals(EmpresaId)
                                            select new EmpresaDto
                                            {
                                                EmpresaId = e.EmpresaId,
                                                Ruc = e.EmpresaRuc,
                                                Nombre = e.EmpresaNombre,
                                                Razon = e.EmpresaRazon,
                                                DireccionMatriz = e.EmpresaDireccionMatriz,
                                                TelefonoMatriz = e.EmpresaTelefonoMatriz,
                                                IdCiudad = c.CiudadId,
                                                Ciudad = c.CiudadNombre,
                                                Estado = e.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (!EmpresaRuc.IsNullOrEmpty() && EmpresaId == 0 && EmpresaNombre.IsNullOrEmpty())
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from e in _context.Empresas
                                            join c in _context.Ciudads on e.CiudadId equals c.CiudadId
                                            where e.Estado.Value == 1 && e.EmpresaRuc.Equals(EmpresaRuc)
                                            select new EmpresaDto
                                            {
                                                EmpresaId = e.EmpresaId,
                                                Ruc = e.EmpresaRuc,
                                                Nombre = e.EmpresaNombre,
                                                Razon = e.EmpresaRazon,
                                                DireccionMatriz = e.EmpresaDireccionMatriz,
                                                TelefonoMatriz = e.EmpresaTelefonoMatriz,
                                                IdCiudad = c.CiudadId,
                                                Ciudad = c.CiudadNombre,
                                                Estado = e.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from e in _context.Empresas
                                            join c in _context.Ciudads on e.CiudadId equals c.CiudadId
                                            where e.Estado.Value == 1
                                            select new EmpresaDto
                                            {
                                                EmpresaId = e.EmpresaId,
                                                Ruc = e.EmpresaRuc,
                                                Nombre = e.EmpresaNombre,
                                                Razon = e.EmpresaRazon,
                                                DireccionMatriz = e.EmpresaDireccionMatriz,
                                                TelefonoMatriz = e.EmpresaTelefonoMatriz,
                                                IdCiudad = c.CiudadId,
                                                Ciudad = c.CiudadNombre,
                                                Estado = e.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("EmpresaService", "GetEmpresa", ex.Message);
            }
            return respuesta;
        }


        public async Task<Respuesta> PostEmpresa(Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Empresas.OrderByDescending(x => x.EmpresaId).Select(x => x.EmpresaId).FirstOrDefault();

                empresa.EmpresaId = Convert.ToInt32(query) + 1;
                empresa.FechaHoraAct = DateTime.Now;
                empresa.FechaHoraReg = DateTime.Now;

                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "000";
                respuesta.Mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("EmpresaService", "PostEmpresa", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutEmpresa(Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                empresa.FechaHoraAct = DateTime.Now;
                _context.Empresas.Update(empresa);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("EmpresaService", "PutEmpresa", ex.Message);
            }
            return respuesta;
        }
    }
}
