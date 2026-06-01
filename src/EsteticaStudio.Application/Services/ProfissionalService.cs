using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Application.Services;

public class ProfissionalService
{
    private readonly IProfissionalRepository _repo;

    public ProfissionalService(IProfissionalRepository repo) => _repo = repo;

    public void Cadastrar(string nome, string especialidade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("O nome do profissional é obrigatório.");
        _repo.Adicionar(new Profissional(nome, especialidade));
    }

    public List<Profissional> Listar() => _repo.Listar();

    public Profissional ObterPorId(Guid id) =>
        _repo.ObterPorId(id) ?? throw new Exception("Profissional não encontrado.");

    public void Atualizar(Guid id, string nome, string especialidade) =>
        ObterPorId(id).Atualizar(nome, especialidade);

    public void Remover(Guid id)
    {
        ObterPorId(id);
        _repo.Remover(id);
    }
}
