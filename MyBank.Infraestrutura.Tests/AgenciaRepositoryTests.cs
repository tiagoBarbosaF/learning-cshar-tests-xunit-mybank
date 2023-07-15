using Microsoft.Extensions.DependencyInjection;
using MyBank.Dados.Repositorio;
using MyBank.Dominio.Interfaces.Repositorios;

namespace MyBank.Infraestrutura.Tests;

public class AgenciaRepositoryTests
{
    private readonly IAgenciaRepositorio? _repositorio;

    public AgenciaRepositoryTests()
    {
        var service = new ServiceCollection();
        service.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();

        var provider = service.BuildServiceProvider();
        _repositorio = provider.GetService<IAgenciaRepositorio>();
    }

    [Fact]
    [Trait("Agencia", "Repository")]
    public void TestGetAllAgencias()
    {
        var agencias = _repositorio?.ObterTodos();

        Assert.NotNull(agencias);

        Assert.Equal(1, agencias?.Count);
    }

    [Fact]
    [Trait("Agencia", "Repository")]
    public void TestGetAgenciaById()
    {
        var agencia = _repositorio?.ObterPorId(1);

        Assert.NotNull(agencia);
    }

    [Theory]
    [Trait("Agencia", "Repository")]
    [InlineData(1)]
    public void TestGetAgenciaByManyIds(int id)
    {
        var agencia = _repositorio?.ObterPorId(id);

        Assert.NotNull(agencia);
    }

    [Fact]
    [Trait("Agencia", "Repository")]
    public void TestExceptionGetAgenciaById()
    {
        Assert.Throws<FormatException>(() => _repositorio?.ObterPorId(3));
    }
}