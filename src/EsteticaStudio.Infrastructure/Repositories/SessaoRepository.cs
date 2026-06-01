using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Infrastructure.Repositories;

public class SessaoRepository : ISessaoRepository
{
    private readonly List<Sessao> _lista = new();

    public void Adicionar(Sessao s) => _lista.Add(s);
    public List<Sessao> Listar() => _lista;
    public Sessao? ObterPorId(Guid id) => _lista.FirstOrDefault(s => s.Id == id);

    public List<Sessao> ListarPorProfissional(Guid profissionalId) =>
        _lista.Where(s => s.Profissional.Id == profissionalId)
              .OrderBy(s => s.DataHorario).ToList();

    public List<Sessao> ListarPorData(DateTime data) =>
        _lista.Where(s => s.DataHorario.Date == data.Date)
              .OrderBy(s => s.DataHorario).ToList();

    public List<Sessao> ListarPorPacote(Guid pacoteId) =>
        _lista.Where(s => s.Pacote.Id == pacoteId)
              .OrderBy(s => s.DataHorario).ToList();
}
