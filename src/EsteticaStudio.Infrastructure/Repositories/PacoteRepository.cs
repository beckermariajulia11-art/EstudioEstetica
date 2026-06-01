using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Infrastructure.Repositories;

public class PacoteSessaoRepository : IPacoteSessaoRepository
{
    private readonly List<PacoteSessao> _lista = new();

    public void Adicionar(PacoteSessao pacote) => _lista.Add(pacote);
    public List<PacoteSessao> Listar() => _lista;
    public PacoteSessao? ObterPorId(Guid id) => _lista.FirstOrDefault(p => p.Id == id);

    public List<PacoteSessao> ListarPorCliente(Guid clienteId) =>
        _lista.Where(p => p.Cliente.Id == clienteId).ToList();
}
