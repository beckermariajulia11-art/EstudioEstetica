using EsteticaStudio.Domain.Entities;

namespace EsteticaStudio.Domain.Interfaces;

public interface ISessaoRepository
{
    void Adicionar(Sessao sessao);
    List<Sessao> Listar();
    Sessao? ObterPorId(Guid id);
    List<Sessao> ListarPorProfissional(Guid profissionalId);
    List<Sessao> ListarPorData(DateTime data);
    List<Sessao> ListarPorPacote(Guid pacoteId);
}
