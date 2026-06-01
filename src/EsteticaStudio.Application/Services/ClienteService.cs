using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Application.Services;

public class ClienteService
{
    private readonly IClienteRepository _repo;

    public ClienteService(IClienteRepository repo) => _repo = repo;

    public void Cadastrar(string nome, string telefone, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("O nome do cliente é obrigatório.");
        _repo.Adicionar(new Cliente(nome, telefone, email));
    }

    public List<Cliente> Listar() => _repo.Listar();

    public Cliente ObterPorId(Guid id) =>
        _repo.ObterPorId(id) ?? throw new Exception("Cliente não encontrado.");

    public void Atualizar(Guid id, string nome, string telefone, string email) =>
        ObterPorId(id).Atualizar(nome, telefone, email);

    public void Remover(Guid id)
    {
        ObterPorId(id);
        _repo.Remover(id);
    }
}
