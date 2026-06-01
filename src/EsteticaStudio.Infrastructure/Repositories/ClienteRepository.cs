using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly List<Cliente> _lista = new();

    public void Adicionar(Cliente cliente) => _lista.Add(cliente);
    public List<Cliente> Listar() => _lista;
    public Cliente? ObterPorId(Guid id) => _lista.FirstOrDefault(c => c.Id == id);
    public void Remover(Guid id)
    {
        var item = ObterPorId(id);
        if (item is not null) _lista.Remove(item);
    }
}
