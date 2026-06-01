using EsteticaStudio.Domain.Entities;
using EsteticaStudio.Domain.Enums;
using EsteticaStudio.Domain.Interfaces;

namespace EsteticaStudio.Application.Services;

public class SessaoService
{
    private readonly ISessaoRepository _repo;
    private readonly IPacoteSessaoRepository _pacoteRepo;
    private readonly IProfissionalRepository _profissionalRepo;

    public SessaoService(ISessaoRepository repo,
                         IPacoteSessaoRepository pacoteRepo,
                         IProfissionalRepository profissionalRepo)
    {
        _repo = repo;
        _pacoteRepo = pacoteRepo;
        _profissionalRepo = profissionalRepo;
    }

    // Agendar sessão — valida saldo, pacote ativo e conflito de horário
    public Sessao Agendar(Guid pacoteId, Guid profissionalId,
                          DateTime dataHorario, string observacoes)
    {
        var pacote = _pacoteRepo.ObterPorId(pacoteId)
            ?? throw new Exception("Pacote não encontrado.");

        if (pacote.Status != StatusPacote.Ativo)
            throw new Exception("Não é possível agendar sessão em um pacote encerrado ou cancelado.");

        if (pacote.SessoesDisponiveis <= 0)
            throw new Exception("Este pacote não possui saldo de sessões disponíveis.");

        var profissional = _profissionalRepo.ObterPorId(profissionalId)
            ?? throw new Exception("Profissional não encontrado.");

        // Verificar conflito de horário para o profissional
        bool conflito = _repo.Listar().Any(s =>
            s.Profissional.Id == profissionalId &&
            s.DataHorario == dataHorario &&
            s.Status != StatusSessao.Cancelada);

        if (conflito)
            throw new Exception("Horário indisponível para este profissional.");

        var sessao = new Sessao(pacote, profissional, dataHorario, observacoes);
        _repo.Adicionar(sessao);
        return sessao;
    }

    public List<Sessao> Listar() => _repo.Listar();

    public Sessao ObterPorId(Guid id) =>
        _repo.ObterPorId(id) ?? throw new Exception("Sessão não encontrada.");

    // Registra comparecimento — consome sessão do pacote
    public void RegistrarComparecimento(Guid sessaoId) =>
        ObterPorId(sessaoId).RegistrarComparecimento();

    // Cancela sessão — impede cancelar sessão já realizada
    public void Cancelar(Guid sessaoId) =>
        ObterPorId(sessaoId).Cancelar();

    // Remarca para nova data/hora — valida conflito também
    public void Remarcar(Guid sessaoId, DateTime novaDataHorario)
    {
        var sessao = ObterPorId(sessaoId);

        bool conflito = _repo.Listar().Any(s =>
            s.Id != sessaoId &&
            s.Profissional.Id == sessao.Profissional.Id &&
            s.DataHorario == novaDataHorario &&
            s.Status != StatusSessao.Cancelada);

        if (conflito)
            throw new Exception("Horário indisponível para este profissional na nova data.");

        sessao.Remarcar(novaDataHorario);
    }

    public List<Sessao> ConsultarPorProfissional(Guid profissionalId) =>
        _repo.ListarPorProfissional(profissionalId);

    public List<Sessao> ConsultarPorData(DateTime data) =>
        _repo.ListarPorData(data);

    public List<Sessao> ConsultarPorPacote(Guid pacoteId) =>
        _repo.ListarPorPacote(pacoteId);
}
