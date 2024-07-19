using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class ProductoServices : IProducto
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public ProductoServices(BaseErpContext context)
        {
            this._context = context;
        }

        //-----------------------------------------------PRODUCTO-------------------------------------------------
        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Productos.OrderByDescending(x => x.ProdId).Select(x => x.ProdId).FirstOrDefault();

                producto.ProdId = Convert.ToInt32(query) + 1;
                producto.FechaHoraReg = DateTime.Now;
                producto.FechaHoraAct = DateTime.Now;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ProductoServices", "PostProducto", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetProducto(int idProducto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<ProductoDto> query = (from p in _context.Productos
                                                 join c in _context.Categoria on p.CategoriaId equals c.CategoriaId
                                                 join emp in _context.Empresas on p.EmpresaId equals emp.EmpresaId
                                                 join pp in _context.Proveedors on p.ProveedorId equals pp.ProvId
                                                 select new ProductoDto
                                                 {
                                                     ProdId = p.ProdId,
                                                     ProdDescripcion = p.ProdDescripcion,
                                                     ProdUltPrecio = p.ProdUltPrecio,
                                                     FechaHoraReg = p.FechaHoraReg,
                                                     FechaHoraAct = p.FechaHoraAct,
                                                     UsuIdAct = p.UsuIdAct,
                                                     UsuIdReg = p.UsuIdReg,
                                                     Estado = p.Estado,
                                                     CategoriaId = p.CategoriaId,
                                                     CategoriaNombre = c.CategoriaDescrip,
                                                     EmpresaId = p.EmpresaId,
                                                     EmpresaNombre = emp.EmpresaNombre,
                                                     ProveedorId = p.ProveedorId,
                                                     ProveedorNombre = p.ProdDescripcion
                                                 });

                if (idProducto != 0)
                {
                    query = query.Where(p => p.ProdId == idProducto);
                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ProductoServices", "GetProducto", ex.Message);
            }
            return respuesta;
        }
    }
}
