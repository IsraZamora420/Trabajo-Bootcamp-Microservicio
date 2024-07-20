using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpresaController : Controller
    {
        private readonly IEmpresa _empresa;
        private ControlError Log = new ControlError();

        public EmpresaController(IEmpresa empresa)
        {
            this._empresa = empresa;
        }

        [HttpGet]
        [Route("GetEmpresa")]
        public async Task<Respuesta> GetEmpresa(int? EmpresaId, string? EmpresaRuc, string? EmpresaNombre)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _empresa.GetEmpresa(EmpresaId,EmpresaRuc, EmpresaNombre);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("EmpresaController", "GetEmpresa", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostEmpresa")]
        public async Task<Respuesta> PostEmpresa([FromBody] Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _empresa.PostEmpresa(empresa);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("EmpresaController", "PostEmpresa", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutEmpresa")]
        public async Task<Respuesta> PutEmpresa([FromBody] Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta= await _empresa.PutEmpresa(empresa);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("EmpresaController", "PutEmpresa", ex.Message);
            }
            return respuesta;
        }
    }
}
