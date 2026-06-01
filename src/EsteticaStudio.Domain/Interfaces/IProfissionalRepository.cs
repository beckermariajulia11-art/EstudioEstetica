using EsteticaStudio.Domain.Entities;

namespace EsteticaStudio.Domain.Interfaces;

public interface IProfissionalRepository
{
    void Adicionar(Profissional profissional);
    List<Profissional> Listar();
    Profissional? ObterPorId(Guid id);
    void Remover(Guid id);
}
