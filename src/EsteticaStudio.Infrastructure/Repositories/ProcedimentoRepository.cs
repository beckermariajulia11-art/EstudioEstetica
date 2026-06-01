using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Infrastructure.Repositories;

public class ProcedimentoRepository : IProcedimentoRepository
{
    private readonly List<Procedimento> _lista = new();

    public void Adicionar(Procedimento p) => _lista.Add(p);
    public List<Procedimento> Listar() => _lista;
    public Procedimento? ObterPorId(Guid id) => _lista.FirstOrDefault(p => p.Id == id);
    public void Remover(Guid id)
    {
        var item = ObterPorId(id);
        if (item is not null) _lista.Remove(item);
    }
}
