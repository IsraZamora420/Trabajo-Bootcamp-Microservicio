using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class StockService : IStock
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public StockService(BaseErpContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> GetStock(int? EmpresaId, int? SucursalId, int? BodegaId, int? ProdId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.codigo = "000";

                if (EmpresaId == 0 && SucursalId == 0 && BodegaId == 0 && ProdId != 0)
                {
                    respuesta.data = await (from s in _context.Stocks
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            join su in _context.Sucursals on s.SucursalId equals su.SucursalId
                                            join b in _context.Bodegas on s.BodegaId equals b.BodegaId
                                            join p in _context.Productos on s.ProdId equals p.ProdId
                                            where s.Estado.Value == 1
                                            && s.ProdId.Equals(ProdId)
                                            select new StockDto
                                            {
                                                ID = s.StockId,
                                                EmpresaId = e.EmpresaId,
                                                NombreEmpresa = e.EmpresaNombre,
                                                SucursalId = su.SucursalId,
                                                SucursalNombre = su.SucursalNombre,
                                                BodegaId = b.BodegaId,
                                                NombreBodega = b.BodegaNombre,
                                                ProductoID = p.ProdId,
                                                NombreProducto = p.ProdDescripcion,
                                                Precio = p.ProdUltPrecio,
                                                Cantidad = s.CantidadStock
                                            }).ToListAsync();
                }
                else if (EmpresaId != 0 && SucursalId == 0 && BodegaId == 0 && ProdId == 0)
                {
                    respuesta.data = await (from s in _context.Stocks
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            join su in _context.Sucursals on s.SucursalId equals su.SucursalId
                                            join b in _context.Bodegas on s.BodegaId equals b.BodegaId
                                            join p in _context.Productos on s.ProdId equals p.ProdId
                                            where s.Estado.Value == 1
                                            && s.EmpresaId.Equals(EmpresaId)
                                            select new StockDto
                                            {
                                                ID = s.StockId,
                                                EmpresaId = e.EmpresaId,
                                                NombreEmpresa = e.EmpresaNombre,
                                                SucursalId = su.SucursalId,
                                                SucursalNombre = su.SucursalNombre,
                                                BodegaId = b.BodegaId,
                                                NombreBodega = b.BodegaNombre,
                                                ProductoID = p.ProdId,
                                                NombreProducto = p.ProdDescripcion,
                                                Precio = p.ProdUltPrecio,
                                                Cantidad = s.CantidadStock
                                            }).ToListAsync();
                }
                else if (EmpresaId != 0 && SucursalId != 0 && BodegaId == 0 && ProdId == 0)
                {
                    respuesta.data = await (from s in _context.Stocks
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            join su in _context.Sucursals on s.SucursalId equals su.SucursalId
                                            join b in _context.Bodegas on s.BodegaId equals b.BodegaId
                                            join p in _context.Productos on s.ProdId equals p.ProdId
                                            where s.Estado.Value == 1
                                            && s.EmpresaId.Equals(EmpresaId)
                                            && s.SucursalId.Equals(SucursalId)
                                            select new StockDto
                                            {
                                                ID = s.StockId,
                                                EmpresaId = e.EmpresaId,
                                                NombreEmpresa = e.EmpresaNombre,
                                                SucursalId = su.SucursalId,
                                                SucursalNombre = su.SucursalNombre,
                                                BodegaId = b.BodegaId,
                                                NombreBodega = b.BodegaNombre,
                                                ProductoID = p.ProdId,
                                                NombreProducto = p.ProdDescripcion,
                                                Precio = p.ProdUltPrecio,
                                                Cantidad = s.CantidadStock
                                            }).ToListAsync();
                }
                else if (EmpresaId != 0 && SucursalId != 0 && BodegaId != 0 && ProdId == 0)
                {
                    respuesta.data = await (from s in _context.Stocks
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            join su in _context.Sucursals on s.SucursalId equals su.SucursalId
                                            join b in _context.Bodegas on s.BodegaId equals b.BodegaId
                                            join p in _context.Productos on s.ProdId equals p.ProdId
                                            where s.Estado.Value == 1
                                            && s.EmpresaId.Equals(EmpresaId)
                                            && s.SucursalId.Equals(SucursalId)
                                            && s.BodegaId.Equals(BodegaId)
                                            select new StockDto
                                            {
                                                ID = s.StockId,
                                                EmpresaId = e.EmpresaId,
                                                NombreEmpresa = e.EmpresaNombre,
                                                SucursalId = su.SucursalId,
                                                SucursalNombre = su.SucursalNombre,
                                                BodegaId = b.BodegaId,
                                                NombreBodega = b.BodegaNombre,
                                                ProductoID = p.ProdId,
                                                NombreProducto = p.ProdDescripcion,
                                                Precio = p.ProdUltPrecio,
                                                Cantidad = s.CantidadStock
                                            }).ToListAsync();
                }
                else if (EmpresaId != 0 && SucursalId != 0 && BodegaId != 0 && ProdId != 0)
                {
                    respuesta.data = await (from s in _context.Stocks
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            join su in _context.Sucursals on s.SucursalId equals su.SucursalId
                                            join b in _context.Bodegas on s.BodegaId equals b.BodegaId
                                            join p in _context.Productos on s.ProdId equals p.ProdId
                                            where s.Estado.Value == 1
                                            && s.EmpresaId.Equals(EmpresaId)
                                            && s.SucursalId.Equals(SucursalId)
                                            && s.BodegaId.Equals(BodegaId)
                                            && s.ProdId.Equals(ProdId)
                                            select new StockDto
                                            {
                                                ID = s.StockId,
                                                EmpresaId = e.EmpresaId,
                                                NombreEmpresa = e.EmpresaNombre,
                                                SucursalId = su.SucursalId,
                                                SucursalNombre = su.SucursalNombre,
                                                BodegaId = b.BodegaId,
                                                NombreBodega = b.BodegaNombre,
                                                ProductoID = p.ProdId,
                                                NombreProducto = p.ProdDescripcion,
                                                Precio = p.ProdUltPrecio,
                                                Cantidad = s.CantidadStock
                                            }).ToListAsync();
                }

                respuesta.mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("StockService", "GetStock", ex.Message);
            }

            return respuesta;
        }

        public async Task<Respuesta> PostStock(Stock stock)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Stocks.OrderByDescending(x => x.StockId).FirstOrDefault();

                stock.StockId = Convert.ToInt32(query) + 1;
                stock.FechaHoraAct = DateTime.Now;
                stock.FechaHoraReg = DateTime.Now;

                _context.Stocks.Add(stock);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {

                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("StockService", "PostStock", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutStock(Stock stock)
        {
            var respuesta = new Respuesta();
            try
            {
                stock.FechaHoraAct = DateTime.Now;
                _context.Stocks.Update(stock);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("StockService", "PutStock", ex.Message);
            }
            return respuesta;
        }
    }
}
