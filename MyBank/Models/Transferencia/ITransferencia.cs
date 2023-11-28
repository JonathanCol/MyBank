namespace MyBank.Models.SQL
{
    public interface ITransferencia
    {
        Task<string>TransferenciaService(TransferenciaRequest transferenciaRequest);
    }
}
