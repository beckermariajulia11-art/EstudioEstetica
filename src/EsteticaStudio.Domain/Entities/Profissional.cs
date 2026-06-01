using EsteticaStudio.Domain.Common;

namespace EsteticaStudio.Domain.Entities;

public class Profissional : Entity
{
    public string Nome { get; private set; }
    public string Especialidade { get; private set; }

    public Profissional(string nome, string especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    }

    public void Atualizar(string nome, string especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    }
}
