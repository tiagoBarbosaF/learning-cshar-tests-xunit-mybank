using MyBank.Dominio.Entidades;

namespace MyBank.Infraestrutura.Tests.Service;

public interface IMyBankRepository
{
    public List<Cliente> GetClients();
    public List<Agencia> GetAgencias();
    public List<ContaCorrente> GetContasCorrente();
}