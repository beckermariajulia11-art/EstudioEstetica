using EsteticaStudio.Domain.Entities;

namespace EsteticaStudio.Domain.Interfaces;

public interface IPacoteSessaoRepository
{
    void Adicionar(PacoteSessao pacote);
    List<PacoteSessao> Listar();
    PacoteSessao? ObterPorId(Guid id);
    List<PacoteSessao> ListarPorCliente(Guid clienteId);
}
