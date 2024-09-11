
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;
        private ControlError Log = new ControlError();

        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }

        //------------------------------------------INDUSTRIA---------------------------------------

        [HttpGet]
        [Route("GetIndustria")]
        public async Task<Respuesta> GetIndustria(int industriaId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetIndustria(industriaId);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetIndustria", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostIndustria")]
        public async Task<Respuesta> PostIndustria([FromBody] Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostIndustria(industria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostIndustria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutIndustria")]
        public async Task<Respuesta> PutIndustria([FromBody] Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutIndustria(industria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutIndustria", ex.Message);
            }
            return respuesta;
        }
        //-----------------------------------MODULO-------------------------------------
        [HttpGet]
        [Route("GetModulo")]
        public async Task<Respuesta> GetModulo(int moduloId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetModulo(moduloId);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetModulo", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostModulo")]
        public async Task<Respuesta> PostModulo([FromBody] Modulo modulo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostModulo(modulo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutModulo")]
        public async Task<Respuesta> PutModulo(Modulo modulo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutModulo(modulo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutModulo", ex.Message);
            }
            return respuesta;
        }
        //-----------------------------------------------CLIENTE-----------------------------------------
        [HttpPost]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var clienteDto = new JsonLogDto();
            try
            {
                clienteDto = JsonConvert.DeserializeObject<JsonLogDto>(Convert.ToString(request.Data));
                respuesta = await _catalogo.GetCliente(clienteDto.idCliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCliente", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCliente", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutCliente")]
        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutCliente", ex.Message);
            }
            return respuesta;
        }

        //-------------------------------------------ROL-------------------------------
        [HttpGet]
        [Route("GetRol")]
        public async Task<Respuesta> GetRol()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetRol();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetRol", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostRol")]
        public async Task<Respuesta> PostRol([FromBody] Rol rol)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostRol(rol);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("RolController", "PostRol", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutRol")]
        public async Task<Respuesta> PutRol([FromBody] Rol rol)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutRol(rol);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisController", "PutRol", ex.Message);
            }
            return respuesta;
        }
        //----------------------------------------------------------------------------------------------
        //-------------------------------------------USUARIO-------------------------------
        [HttpGet]
        [Route("GetUsuario")]
        public async Task<Respuesta> GetUsuario()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetUsuario();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetUsuario", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostUsuario")]
        public async Task<Respuesta> PostUsuario([FromBody] Usuario usuario)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostUsuario(usuario);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("RolController", "PostUsuario", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutUsuario")]
        public async Task<Respuesta> PutUsuario([FromBody] Usuario usuario)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutUsuario(usuario);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisController", "PutUsuario", ex.Message);
            }
            return respuesta;
        }
        //----------------------------------------------------------------------------------------------

        //-------------------------------------------TIPO MOVIMIENTO-------------------------------
        [HttpGet]
        [Route("GetTipoMovimiento")]
        public async Task<Respuesta> GetTipoMovimiento()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetTipoMovimiento();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetTipoMovimiento", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostTipoMovimiento")]
        public async Task<Respuesta> PostTipoMovimiento([FromBody] TipoMovimiento tipoMovimiento)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostTipoMovimiento(tipoMovimiento);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("RolController", "PostTipoMovimiento", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutTipoMovimiento")]
        public async Task<Respuesta> PutTipoMovimiento([FromBody] TipoMovimiento tipoMovimiento)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutTipoMovimiento(tipoMovimiento);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisController", "PutTipoMovimiento", ex.Message);
            }
            return respuesta;
        }
        //----------------------------------------------------------------------------------------------

        //-------------------------------------------PAIS-------------------------------
        [HttpPost]
        [Route("GetPais")]
        public async Task<Respuesta> GetPais([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var paisDto = new JsonLogDto();
            try
            {
                paisDto = JsonConvert.DeserializeObject<JsonLogDto>(Convert.ToString(request.Data));
                respuesta = await _catalogo.GetPais(paisDto.idPais);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetPais", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostPais")]
        public async Task<Respuesta> PostPais([FromBody] Pai pais)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostPais(pais);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostPais", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutPais")]
        public async Task<Respuesta> PutPais([FromBody] Pai pais)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutPais(pais);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisController", "PutPais", ex.Message);
            }
            return respuesta;
        }

        //-------------------------------------------CATEGORIA------------------------------------------
        [HttpPost]
        [Route("PostCategoria")]
        public async Task<Respuesta> PostCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("GetCategoria")]
        public async Task<Respuesta> GetCategoria([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var catalogoDto = new JsonLogDto();
            try
            {
                catalogoDto = JsonConvert.DeserializeObject<JsonLogDto>(Convert.ToString(request.Data));
                respuesta = await _catalogo.GetCategoria(catalogoDto.idCatalogo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCategoria")]
        public async Task<Respuesta> PutCategoria(Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutCategoria", ex.Message);
            }
            return respuesta;
        }
        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------FORMA DE PAGO------------------------------------------
        [HttpGet]
        [Route("GetFormaPago")]
        public async Task<Respuesta> GetFormaPago(int idPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetFormaPago(idPago);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetFormaPago", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostFormaPago")]
        public async Task<Respuesta> PostFormaPago([FromBody] FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostFormaPago(formaPago);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostFormaPago", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutFormaPago")]
        public async Task<Respuesta> PutFormaPago([FromBody] FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutFormaPago(formaPago);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutFormaPago", ex.Message);
            }
            return respuesta;
        }
    }
}
