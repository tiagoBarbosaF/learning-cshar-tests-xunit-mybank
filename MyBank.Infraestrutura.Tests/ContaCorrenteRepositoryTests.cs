using Microsoft.Extensions.DependencyInjection;
using Moq;
using MyBank.Dados.Repositorio;
using MyBank.Dominio.Entidades;
using MyBank.Dominio.Interfaces.Repositorios;
using MyBank.Infraestrutura.Tests.Service;
using MyBank.Infraestrutura.Tests.Service.DTOs;

namespace MyBank.Infraestrutura.Tests;

public class ContaCorrenteRepositoryTests
{
    private readonly IContaCorrenteRepositorio? _repositorio;

    public ContaCorrenteRepositoryTests()
    {
        var service = new ServiceCollection();
        service.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();

        var provider = service.BuildServiceProvider();
        _repositorio = provider.GetService<IContaCorrenteRepositorio>();
    }

    [Fact]
    [Trait("Conta Corrente", "Repository")]
    public void TestGetAllContaCorrentes()
    {
        var listContaCorrentes = _repositorio?.ObterTodos();

        Assert.NotNull(listContaCorrentes);

        Assert.Equal(2, listContaCorrentes?.Count);
    }

    [Fact]
    [Trait("Conta Corrente", "Repository")]
    public void TestGetContaCorrenteById()
    {
        var contaCorrente = _repositorio?.ObterPorId(1);

        Assert.NotNull(contaCorrente);
    }

    [Theory]
    [Trait("Conta Corrente", "Repository")]
    [InlineData(1)]
    [InlineData(2)]
    public void TestGetContaCorrenteByManyIds(int id)
    {
        var contaCorrente = _repositorio?.ObterPorId(id);

        Assert.NotNull(contaCorrente);
    }

    [Fact]
    [Trait("Conta Corrente", "Repository")]
    public void TestUpdateSaldoContaCorrente()
    {
        var contaCorrente = _repositorio?.ObterPorId(1);
        var newSaldo = 15;

        if (contaCorrente != null) contaCorrente.Saldo = newSaldo;

        var updated = _repositorio?.Atualizar(1, contaCorrente);

        Assert.True(updated);
    }

    [Fact]
    [Trait("Conta Corrente", "Repository")]
    public void TestInsertNewContaCorrente()
    {
        var contaCorrente = new ContaCorrente
        {
            Saldo = 100,
            Identificador = Guid.NewGuid(),

            Cliente = new Cliente
            {
                Nome = "Peter Parker",
                CPF = "333.333.333-33",
                Identificador = Guid.NewGuid(),
                Profissao = "Photographer"
            },
            Agencia = new Agencia
            {
                Nome = "New York Central",
                Identificador = Guid.NewGuid(),
                Endereco = "Street Core",
                Numero = 1010
            }
        };

        var response = _repositorio?.Adicionar(contaCorrente);

        Assert.True(response);
    }

    [Fact]
    [Trait("Conta Corrente", "Repository")]
    public void TestGetAllPix()
    {
        var guid = new Guid("c3aed3f9-380b-4305-9c79-f0a8c326007c");

        var pix = new PixDTO
        {
            Key = guid, Saldo = 68
        };

        var pixMock = new Mock<IPixRepository>();

        pixMock.Setup(x => x.getPix(It.IsAny<Guid>())).Returns(pix);

        var mock = pixMock.Object;

        var saldo = mock.getPix(guid)?.Saldo;

        Assert.Equal(68, saldo);
    }
}