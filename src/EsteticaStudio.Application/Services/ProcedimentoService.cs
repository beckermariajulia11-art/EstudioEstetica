using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Application.Services;

public class ProcedimentoService
{
    private readonly IProcedimentoRepository _repo;

    public ProcedimentoService(IProcedimentoRepository repo) => _repo = repo;

    public void Cadastrar(string nome, int duracaoMinutos, string descricao)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("O nome do procedimento é obrigatório.");
        if (duracaoMinutos <= 0)
            throw new Exception("A duração deve ser maior que zero.");
        _repo.Adicionar(new Procedimento(nome, duracaoMinutos, descricao));
    }

    public List<Procedimento> Listar() => _repo.Listar();

    public Procedimento ObterPorId(Guid id) =>
        _repo.ObterPorId(id) ?? throw new Exception("Procedimento não encontrado.");

    public void Atualizar(Guid id, string nome, int duracaoMinutos, string descricao) =>
        ObterPorId(id).Atualizar(nome, duracaoMinutos, descricao);

    public void Remover(Guid id)
    {
        ObterPorId(id);
        _repo.Remover(id);
    }
}
