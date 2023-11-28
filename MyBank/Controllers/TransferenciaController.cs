using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBank.Models;
using MyBank.Models.SQL;

namespace MyBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferencia transacciones;
        
        public TransferenciaController(ITransferencia transacciones) 
        {
            this.transacciones = transacciones;
        
        }

        [HttpPost]
        public async Task<ActionResult> Transferencia([FromBody] TransferenciaRequest transferenciaRequest)
        {
            
            var result = await transacciones.TransferenciaService(transferenciaRequest);
            return Ok(result);
        }
    }
}
