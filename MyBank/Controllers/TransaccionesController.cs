using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBank.Models;
using MyBank.Models.Transacciones;

namespace MyBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly ITransacciones transacciones;

        public TransaccionesController(ITransacciones transacciones)
        {
            this.transacciones = transacciones;
        }

        [HttpGet]

        public async Task<ActionResult<List<string>>> Get()
        {
            var consulta = await transacciones.GetTransacciones();

            return consulta == null? NotFound() : Ok(consulta);
        }

    }
}
