using EsteticaStudio.Domain.Common;

namespace EsteticaStudio.Domain.Entities;

public class Cliente : Entity
{
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }

    public Cliente(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }

    public void Atualizar(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}
