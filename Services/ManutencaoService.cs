using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.ViewModels.Manutencao;

namespace VoeAirlines.Services
{
    public class ManutencaoService
    {
        public readonly VoeAirlinesContext _context;

        public ManutencaoService(VoeAirlinesContext context)
        {
            _context = context;
        }

        public DetalhesManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados)
        {
            var manutencao = new Manutencao(dados.DataHora,dados.TipoManutencao,dados.AeronaveId,dados.Observacao);
            _context.Add(manutencao);
            _context.SaveChanges();

            return new DetalhesManutencaoViewModel(manutencao.Id,manutencao.DataHora,manutencao.TipoManutencao,manutencao.Observacao,manutencao.AeronaveId);
        }

        //public DetalhesManutencaoViewModel AtualizarManutencao(int id, AtualizarManutencaoViewModel dados)
        //{
        //    var manutencaoParaAtualizar = _context.Manutencoes.Find(id);
        //    if (manutencaoParaAtualizar != null)
        //    {
        //        var manutencao = new Manutencao(dados.DataHora, dados.TipoManutencao, dados.AeronaveId, dados.Observacao);
        //        _context.Update
                
        //    }
            
        //}
    }
}
