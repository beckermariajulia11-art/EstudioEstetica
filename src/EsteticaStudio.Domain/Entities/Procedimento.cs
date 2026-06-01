using EsteticaStudio.Domain.Common;

namespace EsteticaStudio.Domain.Entities;

public class Procedimento : Entity
{
    public string Nome { get; private set; }
    public int DuracaoMinutos { get; private set; }
    public string Descricao { get; private set; }

    public Procedimento(string nome, int duracaoMinutos, string descricao)
    {
        Nome = nome;
        DuracaoMinutos = duracaoMinutos;
        Descricao = descricao;
    }

    public void Atualizar(string nome, int duracaoMinutos, string descricao)
    {
        Nome = nome;
        DuracaoMinutos = duracaoMinutos;
        Descricao = descricao;
    }
}
