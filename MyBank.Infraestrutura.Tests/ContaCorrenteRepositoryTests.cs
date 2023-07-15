using Microsoft.Extensions.DependencyInjection;
using MyBank.Dados.Repositorio;
using MyBank.Dominio.Entidades;
using MyBank.Dominio.Interfaces.Repositorios;

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
}