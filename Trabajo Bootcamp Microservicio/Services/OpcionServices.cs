using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class OpcionServices : IOpcion
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public OpcionServices(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> PostOpcion(Opcion opcion)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Opcions.OrderByDescending(o => o.OpcionId).Select(o => o.OpcionId).FirstOrDefault();

                opcion.OpcionId = Convert.ToInt32(query) + 1;
                opcion.FechaHoraReg = DateTime.Now;
                opcion.FechaHoraAct = DateTime.Now;

                _context.Opcions.Add(opcion);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("OpcionServices", "PostOpcion", ex.Message);
            }

            return respuesta;
        }
        public async Task<Respuesta> GetOpcion(int Opcion)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<OpcionDto> query = (from o in _context.Opcions
                                                       join op in _context.Opcions on o.OpcionId equals op.OpcionId
                                                       join m in _context.Modulos on o.ModuloId equals m.ModuloId
                                                       select new OpcionDto
                                                       {
                                                           OpcionId = o.OpcionId,
                                                           OpcionDescripcion = op.OpcionDescripcion,
                                                           Estado = o.Estado,
                                                           FechaHoraReg = o.FechaHoraReg,
                                                           FechaHoraAct = o.FechaHoraAct,
                                                           UsuIdReg = o.UsuIdReg,
                                                           UsuIdAct = o.UsuIdAct,
                                                           ModuloId = o.ModuloId,
                                                           ModuloDescripcion = m.ModuloDescripcion

                                                       });

                if (Opcion != 0)
                {
                    query = query.Where(o => o.OpcionId == Opcion);
                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("OpcionServices", "GetOpcion", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutOpcion(Opcion opcion)
        {
            var respuesta = new Respuesta();
            try
            {
                opcion.FechaHoraAct = DateTime.Now;
                _context.Opcions.Update(opcion);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("OpcionServices", "PutOpcion", ex.Message);
            }
            return respuesta;
        }
    }
}