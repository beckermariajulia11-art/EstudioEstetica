using EsteticaStudio.Domain.Entities;

namespace EsteticaStudio.Domain.Interfaces;

public interface IProcedimentoRepository
{
    void Adicionar(Procedimento procedimento);
    List<Procedimento> Listar();
    Procedimento? ObterPorId(Guid id);
    void Remover(Guid id);
}
