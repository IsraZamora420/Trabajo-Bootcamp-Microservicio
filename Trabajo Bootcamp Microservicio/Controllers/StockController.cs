using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private IStock _stock;
        private ControlError Log = new ControlError();
        public StockController(IStock stock)
        {
            this._stock = stock;
        }

        [HttpGet]
        [Route("GetStock")]
        public async Task<Respuesta> GetStock(int? EmpresaId, int? SucursalId, int? BodegaId, int? ProdId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _stock.GetStock(EmpresaId, SucursalId, BodegaId, ProdId);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("StockController", "GetStock", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostStock")]
        public async Task<Respuesta> PostStock([FromBody] Stock stock)
        {
            var respuesta = new Respuesta();
            try
            {
                await _stock.PostStock(stock);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("StockController", "PostStock", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutStock")]
        public async Task<Respuesta> PutStock([FromBody] Stock stock)
        {
            var respuesta = new Respuesta();
            try
            {
                await _stock.PutStock(stock);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("StockController", "PutStock", ex.Message);
            }
            return respuesta;
        }
    }
}
