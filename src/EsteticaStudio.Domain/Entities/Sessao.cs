using EsteticaStudio.Domain.Common;
using EsteticaStudio.Domain.Enums;

namespace EsteticaStudio.Domain.Entities;

public class Sessao : Entity
{
    public PacoteSessao Pacote { get; private set; }
    public Profissional Profissional { get; private set; }
    public DateTime DataHorario { get; private set; }
    public StatusSessao Status { get; private set; }
    public string Observacoes { get; private set; }

    public Sessao(PacoteSessao pacote, Profissional profissional,
                  DateTime dataHorario, string observacoes)
    {
        Pacote = pacote;
        Profissional = profissional;
        DataHorario = dataHorario;
        Status = StatusSessao.Agendada;
        Observacoes = observacoes;
    }

    // Registra que o cliente compareceu — consome uma sessão do pacote
    public void RegistrarComparecimento()
    {
        if (Status != StatusSessao.Agendada && Status != StatusSessao.Remarcada)
            throw new Exception("Somente sessões agendadas ou remarcadas podem ser realizadas.");

        Pacote.RegistrarUsoSessao();
        Status = StatusSessao.Realizada;
    }

    // Cancela a sessão; se já estava realizada, impede
    public void Cancelar()
    {
        if (Status == StatusSessao.Realizada)
            throw new Exception("Não é possível cancelar uma sessão já realizada.");
        if (Status == StatusSessao.Cancelada)
            throw new Exception("Esta sessão já está cancelada.");

        Status = StatusSessao.Cancelada;
    }

    // Remarca para nova data/hora
    public void Remarcar(DateTime novaDataHorario)
    {
        if (Status == StatusSessao.Realizada)
            throw new Exception("Sessão já realizada não pode ser remarcada.");
        if (Status == StatusSessao.Cancelada)
            throw new Exception("Sessão cancelada não pode ser remarcada.");

        DataHorario = novaDataHorario;
        Status = StatusSessao.Remarcada;
    }
}
