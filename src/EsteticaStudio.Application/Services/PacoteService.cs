using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Application.Services;

public class PacoteService
{
    private readonly IPacoteSessaoRepository _repo;
    private readonly IClienteRepository _clienteRepo;
    private readonly IProcedimentoRepository _procedimentoRepo;

    public PacoteService(IPacoteSessaoRepository repo,
                         IClienteRepository clienteRepo,
                         IProcedimentoRepository procedimentoRepo)
    {
        _repo = repo;
        _clienteRepo = clienteRepo;
        _procedimentoRepo = procedimentoRepo;
    }

    // Vender pacote: cria e persiste
    public PacoteSessao VenderPacote(Guid clienteId, Guid procedimentoId,
                                     int quantidade, decimal valor)
    {
        var cliente = _clienteRepo.ObterPorId(clienteId)
            ?? throw new Exception("Cliente não encontrado.");
        var procedimento = _procedimentoRepo.ObterPorId(procedimentoId)
            ?? throw new Exception("Procedimento não encontrado.");

        var pacote = new PacoteSessao(cliente, procedimento, quantidade, valor);
        _repo.Adicionar(pacote);
        return pacote;
    }

    public List<PacoteSessao> Listar() => _repo.Listar();

    public PacoteSessao ObterPorId(Guid id) =>
        _repo.ObterPorId(id) ?? throw new Exception("Pacote não encontrado.");

    // Consulta saldo de sessões de todos os pacotes ativos de um cliente
    public List<PacoteSessao> ConsultarSaldoPorCliente(Guid clienteId) =>
        _repo.ListarPorCliente(clienteId);

    public void Cancelar(Guid id) => ObterPorId(id).Cancelar();
}
