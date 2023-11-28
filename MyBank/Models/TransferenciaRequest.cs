namespace MyBank.Models
{
    public class TransferenciaRequest
    {
        public int CedulaOrigen { get; set; }

        public int CedulaDestino { get; set; }

        public int CuentaOrigen { get; set; }

        public int CuentaDestino { get; set; }

        public double MontoTransferencia { get; set; }
    }
     
}
