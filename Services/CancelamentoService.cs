using VoeAirlines.Contexts;
using VoeAirlines.Entities;

using VoeAirlines.ViewModels.Cancelamento;

namespace VoeAirlines.Services
{
    public class CancelamentoService
    {
        private readonly VoeAirlinesContext _context;

        public CancelamentoService(VoeAirlinesContext context)
        {
            _context = context;
        }

        public DetalhesCancelamentoViewModel AdicionarCancelamento(AdicionarCancelamentoViewModel dados)
        {
            var cancelamento = new Cancelamento(dados.Motivo, dados.DataHoraNotificacao, dados.VooId);

            _context.Add(cancelamento);
            _context.SaveChanges();

            return new DetalhesCancelamentoViewModel(cancelamento.Id, cancelamento.Motivo, cancelamento.DataHoraNotificacao, cancelamento.VooId);
        }

        public DetalhesCancelamentoViewModel? AtualizarCancelamento(int id, AtualizarCancelamentoViewModel dados)
        {
            var cancelamentoParaAtualizar = _context.Cancelamentos.Find(id);
            if (cancelamentoParaAtualizar != null)
            {
                if (id == cancelamentoParaAtualizar.Id)
                {
                    var cancelamentoAtualizada = new AtualizarCancelamentoViewModel(dados.Motivo, dados.DataHoraNotificacao, dados.VooId);
                    _context.Update(cancelamentoAtualizada);
                    _context.SaveChanges();
                    return new DetalhesCancelamentoViewModel(cancelamentoParaAtualizar.Id, cancelamentoParaAtualizar.Motivo, cancelamentoParaAtualizar.DataHoraNotificacao, cancelamentoParaAtualizar.VooId);
                }
            }
            return null;
        }

        public IEnumerable<ListarCancelamentoViewModel> ListarCancelamentos()
        {
            return _context.Cancelamentos.Select(x => new ListarCancelamentoViewModel(x.Id, x.Motivo, x.DataHoraNotificacao, x.VooId));

        }

        public ListarCancelamentoViewModel? ListarCancelamentoPorId(int id)
        {
            var cancelamento = _context.Cancelamentos.Find(id);
            if (cancelamento != null)
            {
                return new ListarCancelamentoViewModel(cancelamento.Id, cancelamento.Motivo, cancelamento.DataHoraNotificacao, cancelamento.VooId);
            }
            return null;
        }

        public DetalhesCancelamentoViewModel? RemoverCancelamento(int id)
        {
            var cancelamentoParaRemover = _context.Cancelamentos.Find(id);
            if (cancelamentoParaRemover != null)
            {
                if (id == cancelamentoParaRemover.Id)
                {
                    _context.Cancelamentos.Remove(cancelamentoParaRemover);
                    _context.SaveChanges();
                    return new DetalhesCancelamentoViewModel(cancelamentoParaRemover.Id, cancelamentoParaRemover.Motivo, cancelamentoParaRemover.DataHoraNotificacao, cancelamentoParaRemover.VooId);
                }

            }
            return null;

        }
    }
}
