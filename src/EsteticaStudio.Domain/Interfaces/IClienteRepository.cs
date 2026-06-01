using EsteticaStudio.Domain.Entities;

namespace EsteticaStudio.Domain.Interfaces;

public interface IClienteRepository
{
    void Adicionar(Cliente cliente);
    List<Cliente> Listar();
    Cliente? ObterPorId(Guid id);
    void Remover(Guid id);
}
