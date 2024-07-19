using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Trabajo_Bootcamp_Microservicio.Dtos;
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
                    respuesta.codigo = "000";
                    respuesta.data = await (from e in _context.Empresas
                                            join c in _context.Ciudads on e.CiudadId equals c.CiudadId
                                            where e.Estado.Equals("A") && e.EmpresaId.Equals(EmpresaId) && e.EmpresaRuc.Equals(EmpresaRuc)
                                            select new EmpresaDto
                                            {
                                                Id = e.EmpresaId,
                                                Ruc = e.EmpresaRuc,
                                                Nombre = e.EmpresaNombre,
                                                Razon = e.EmpresaNombre,
                                                DireccionMatriz = e.EmpresaDireccionMatriz,
                                                TelefonoMatriz = e.EmpresaTelefonoMatriz,
                                                Ciudad = c.CiudadNombre,
                                                Estado = e.Estado
                                            }).ToListAsync();
                    respuesta.mensaje = "OK";
                }
                else if (EmpresaId != 0 && EmpresaNombre.IsNullOrEmpty() && EmpresaRuc.IsNullOrEmpty())
                {
                    respuesta.codigo = "000";
                    respuesta.data = await (from e in _context.Empresas
                                            join c in _context.Ciudads on e.CiudadId equals c.CiudadId
                                            where e.Estado.Equals("A") && e.EmpresaId.Equals(EmpresaId)
                                            select new EmpresaDto
                                            {
                                                Id = e.EmpresaId,
                                                Ruc = e.EmpresaRuc,
                                                Nombre = e.EmpresaNombre,
                                                Razon = e.EmpresaNombre,
                                                DireccionMatriz = e.EmpresaDireccionMatriz,
                                                TelefonoMatriz = e.EmpresaTelefonoMatriz,
                                                Ciudad = c.CiudadNombre,
                                                Estado = e.Estado
                                            }).ToListAsync();
                    respuesta.mensaje = "OK";
                }
                else if (!EmpresaRuc.IsNullOrEmpty() && EmpresaId == 0 && EmpresaNombre.IsNullOrEmpty())
                {
                    respuesta.codigo = "000";
                    respuesta.data = await (from e in _context.Empresas
                                            join c in _context.Ciudads on e.CiudadId equals c.CiudadId
                                            where e.Estado.Equals("A") && e.EmpresaRuc.Equals(EmpresaRuc)
                                            select new EmpresaDto
                                            {
                                                Id = e.EmpresaId,
                                                Ruc = e.EmpresaRuc,
                                                Nombre = e.EmpresaNombre,
                                                Razon = e.EmpresaNombre,
                                                DireccionMatriz = e.EmpresaDireccionMatriz,
                                                TelefonoMatriz = e.EmpresaTelefonoMatriz,
                                                Ciudad = c.CiudadNombre,
                                                Estado = e.Estado
                                            }).ToListAsync();
                    respuesta.mensaje = "OK";
                }
                else
                {
                    respuesta.codigo = "000"; 
                    respuesta.mensaje = "No se proporcionaron suficientes parámetros para realizar la consulta.";
                }
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("EmpresaService", "GetEmpresa", ex.Message);
            }
            return respuesta;
        }


        public async Task<Respuesta> PostEmpresa(Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Empresas.OrderByDescending(x => x.EmpresaId).FirstOrDefault();

                empresa.EmpresaId = Convert.ToInt32(query) + 1;
                empresa.FechaHoraAct = DateTime.Now;
                empresa.FechaHoraReg = DateTime.Now;

                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {

                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
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

                respuesta.codigo = "000";
                respuesta.mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("EmpresaService", "PutEmpresa", ex.Message);
            }
            return respuesta;
        }
    }
}
