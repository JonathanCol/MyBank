namespace MyBank.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public int Cuenta { get; set; }
        public int Cedula { get; set;}

        public double Saldo { get; set; }

        public string Nombre { get; set; }
    }
}
