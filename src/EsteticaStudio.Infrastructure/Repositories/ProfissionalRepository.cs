using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Infrastructure.Repositories;

public class ProfissionalRepository : IProfissionalRepository
{
    private readonly List<Profissional> _lista = new();

    public void Adicionar(Profissional p) => _lista.Add(p);
    public List<Profissional> Listar() => _lista;
    public Profissional? ObterPorId(Guid id) => _lista.FirstOrDefault(p => p.Id == id);
    public void Remover(Guid id)
    {
        var item = ObterPorId(id);
        if (item is not null) _lista.Remove(item);
    }
}
