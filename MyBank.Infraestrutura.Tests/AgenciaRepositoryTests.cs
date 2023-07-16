using Microsoft.Extensions.DependencyInjection;
using Moq;
using MyBank.Dados.Repositorio;
using MyBank.Dominio.Entidades;
using MyBank.Dominio.Interfaces.Repositorios;
using MyBank.Infraestrutura.Tests.Service;

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

        Assert.Equal(2, agencias?.Count);
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

    [Fact]
    [Trait("Agencia", "Repository")]
    public void TestAddAgenciaMock()
    {
        var agencia = new Agencia
        {
            Nome = "Agência Central",
            Identificador = Guid.NewGuid(),
            Id = 1,
            Endereco = "Avenida Principal",
            Numero = 123
        };

        var mock = new MyBankRepository();

        var added = mock.AddAgencia(agencia);

        Assert.True(added);
    }

    [Fact]
    [Trait("Agencia", "Repository")]
    public void TestGetAgenciaMock()
    {
        var myBankMock = new Mock<IMyBankRepository>();

        var mock = myBankMock.Object;

        var list = mock.GetAgencias();

        myBankMock.Verify(agencia => agencia.GetAgencias());
    }
}