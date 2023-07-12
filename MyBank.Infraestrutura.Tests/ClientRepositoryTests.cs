using Microsoft.Extensions.DependencyInjection;
using MyBank.Dados.Repositorio;
using MyBank.Dominio.Interfaces.Repositorios;

namespace MyBank.Infraestrutura.Tests;

public class ClientRepositoryTests
{
    private readonly IClienteRepositorio? _repositorio;

    public ClientRepositoryTests()
    {
        var service = new ServiceCollection();
        service.AddTransient<IClienteRepositorio, ClienteRepositorio>();
        var provider = service.BuildServiceProvider();
        _repositorio = provider.GetService<IClienteRepositorio>();
    }

    [Fact]
    public void TestGetAllClients()
    {
        var listClients = _repositorio?.ObterTodos();

        Assert.NotNull(listClients);
        Assert.Equal(2, listClients?.Count);
    }
}