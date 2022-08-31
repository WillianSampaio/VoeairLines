namespace VoeAirlines.ViewModels.Cancelamento
{
    public class AdicionarCancelamentoViewModel
    {
        public int Id { get; set; }
        public string Motivo { get; set; }
        public DateTime DataHoraNotificacao { get; set; }
        public int VooId { get; set; }

        public AdicionarCancelamentoViewModel(string motivo, DateTime dataHoraNotificacao, int vooId)
        {
            Motivo = motivo;
            DataHoraNotificacao = dataHoraNotificacao;
            VooId = vooId;
        }
    }
}
