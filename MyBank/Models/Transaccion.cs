namespace MyBank.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public int Cuenta_Origen { get; set; }

        public int Cuenta_Destino { get; set; }

        public double Monto_Transferido { get; set; }
    }
}
