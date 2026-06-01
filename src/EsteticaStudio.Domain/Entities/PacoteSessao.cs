using EsteticaStudio.Domain.Common;
using EsteticaStudio.Domain.Enums;

namespace EsteticaStudio.Domain.Entities;

public class PacoteSessao : Entity
{
    public Cliente Cliente { get; private set; }
    public Procedimento Procedimento { get; private set; }
    public int QuantidadeContratada { get; private set; }
    public int SessoesUtilizadas { get; private set; }
    public decimal Valor { get; private set; }
    public StatusPacote Status { get; private set; }

    // Calculado: quanto resta no pacote
    public int SessoesDisponiveis => QuantidadeContratada - SessoesUtilizadas;

    public PacoteSessao(Cliente cliente, Procedimento procedimento,
                        int quantidadeContratada, decimal valor)
    {
        if (quantidadeContratada <= 0)
            throw new Exception("A quantidade de sessões deve ser maior que zero.");
        if (valor < 0)
            throw new Exception("O valor não pode ser negativo.");

        Cliente = cliente;
        Procedimento = procedimento;
        QuantidadeContratada = quantidadeContratada;
        SessoesUtilizadas = 0;
        Valor = valor;
        Status = StatusPacote.Ativo;
    }

    // Chamado ao registrar comparecimento de uma sessão
    public void RegistrarUsoSessao()
    {
        if (Status != StatusPacote.Ativo)
            throw new Exception("Não é possível usar sessão de um pacote encerrado ou cancelado.");
        if (SessoesDisponiveis <= 0)
            throw new Exception("Este pacote não possui sessões disponíveis.");

        SessoesUtilizadas++;

        if (SessoesDisponiveis == 0)
            Status = StatusPacote.Encerrado;
    }

    // Chamado ao cancelar uma sessão já realizada (estorno)
    public void EstornarSessao()
    {
        if (SessoesUtilizadas <= 0)
            throw new Exception("Não há sessões utilizadas para estornar.");

        SessoesUtilizadas--;

        if (Status == StatusPacote.Encerrado)
            Status = StatusPacote.Ativo;
    }

    public void Cancelar()
    {
        if (Status == StatusPacote.Encerrado)
            throw new Exception("Pacote encerrado não pode ser cancelado.");
        Status = StatusPacote.Cancelado;
    }
}
