using Microsoft.EntityFrameworkCore;

namespace MyBank.Models.SQL
{
    public class Transferencia : ITransferencia
    {
        private readonly ApplicationDbContext _context;

        public Transferencia(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public async Task<string> TransferenciaService(TransferenciaRequest transferenciaRequest)
        {

            List<Clientes> cliente_origen = new List<Clientes>();
            List<Clientes> cliente_destino = new List<Clientes>();

            Transaccion infoTransaccion = new Transaccion(); 
            var transferenciaResponse = "";

            using (_context)
            {
                var datos_origen = _context.Clientes.Where( o => o.Cedula == transferenciaRequest.CedulaOrigen);
                var datos_destino = _context.Clientes.Where(d => d.Cedula == transferenciaRequest.CedulaDestino);
                

                cliente_origen = datos_origen.ToList();
                cliente_destino = datos_destino.ToList();

                if (cliente_origen[0].Saldo <= 0) { return "No hay saldo para la transferencia"; }
                if (cliente_origen[0].Cuenta == cliente_destino[0].Cuenta || cliente_origen[0].Cedula == cliente_destino[0].Cedula) { return "La informacion digita no puede repetirse";}
                if (cliente_origen[0].Cuenta != transferenciaRequest.CuentaOrigen) { return $"la cuenta {cliente_origen[0].Cuenta} no coincide con la cedula digitada {cliente_origen[0].Cedula}";}
                if (cliente_destino[0].Cuenta != transferenciaRequest.CuentaOrigen) { return $"la cuenta {cliente_destino[0].Cuenta} no coincide con la cedula digitada {cliente_destino[0].Cedula}";}

                cliente_origen[0].Saldo = cliente_origen[0].Saldo - transferenciaRequest.MontoTransferencia;
                cliente_destino[0].Saldo = cliente_destino[0].Saldo + transferenciaRequest.MontoTransferencia;

                
                var transaccionAdd = _context.Transacciones.Add( new Transaccion()
                {
                    Cuenta_Origen = cliente_origen[0].Cuenta,
                    Cuenta_Destino = cliente_destino[0].Cuenta,
                    Monto_Transferido = transferenciaRequest.MontoTransferencia
                });

                _context.SaveChanges();
                _context.Database.CloseConnection();

                transferenciaResponse = $"La transferencia de {transferenciaRequest.MontoTransferencia} desde la cuenta {cliente_origen[0].Cuenta} a la cuenta {cliente_destino[0].Cuenta} ha sido exitosa";

            }

            return transferenciaResponse;
        }
        
    }
}
