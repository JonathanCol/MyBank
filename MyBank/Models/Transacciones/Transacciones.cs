using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyBank.Models.Transacciones
{
    public class Transacciones : ITransacciones
    {
        private readonly ApplicationDbContext _context;

        public Transacciones(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetTransacciones()
        {
            string responseJson;
            List<Transaccion> response = new List<Transaccion>();
            using (_context)
            {
                var consulta = _context.Transacciones.ToList();

                response = consulta.ToList();

                responseJson = JsonSerializer.Serialize(response);

            }
            return responseJson;
        }
    }
}
