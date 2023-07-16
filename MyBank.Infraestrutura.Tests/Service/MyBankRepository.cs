using MyBank.Dominio.Entidades;

namespace MyBank.Infraestrutura.Tests.Service;

public class MyBankRepository : IMyBankRepository
{
    private List<Cliente> _clients = new()
    {
        new Cliente
        {
            Nome = "João da Silva",
            CPF = "183.659.570-00",
            Identificador = Guid.NewGuid(),
            Profissao = "Engenheiro",
            Id = 1
        },
        new Cliente
        {
            Nome = "Maria Souza",
            CPF = "957.958.980-15",
            Identificador = Guid.NewGuid(),
            Profissao = "Advogada",
            Id = 2
        },
        new Cliente
        {
            Nome = "Pedro Santos",
            CPF = "177.861.340-34",
            Identificador = Guid.NewGuid(),
            Profissao = "Médico",
            Id = 3
        },
        new Cliente
        {
            Nome = "Ana Oliveira",
            CPF = "588.408.970-89",
            Identificador = Guid.NewGuid(),
            Profissao = "Professor",
            Id = 4
        },
        new Cliente
        {
            Nome = "Lucas Costa",
            CPF = "427.705.610-57",
            Identificador = Guid.NewGuid(),
            Profissao = "Analista de Sistemas",
            Id = 5
        }
    };

    public List<Cliente> Clients => _clients;

    private List<Agencia> _agencias = new()
    {
        new Agencia
        {
            Nome = "Agência Central",
            Identificador = Guid.NewGuid(),
            Id = 1,
            Endereco = "Avenida Principal",
            Numero = 123
        },
        new Agencia
        {
            Nome = "Agência do Povo",
            Identificador = Guid.NewGuid(),
            Id = 2,
            Endereco = "Rua das Flores",
            Numero = 456
        },
        new Agencia
        {
            Nome = "Agência Nova Era",
            Identificador = Guid.NewGuid(),
            Id = 3,
            Endereco = "Praça Central",
            Numero = 789
        }
    };

    public List<Agencia> Agencias => _agencias;

    private List<ContaCorrente> _contaCorrentes = new()
    {
        new ContaCorrente
        {
            Saldo = 50,
            Id = 1,
            Identificador = Guid.NewGuid(),
            Cliente = new Cliente
            {
                Nome = "Maria Souza",
                CPF = "957.958.980-15",
                Identificador = Guid.NewGuid(),
                Profissao = "Advogada",
                Id = 2
            },
            Agencia = new Agencia
            {
                Nome = "Agência do Povo",
                Identificador = Guid.NewGuid(),
                Id = 2,
                Endereco = "Rua das Flores",
                Numero = 456
            }
        },
        new ContaCorrente
        {
            Saldo = 100,
            Id = 2,
            Identificador = Guid.NewGuid(),
            Cliente = new Cliente
            {
                Nome = "Ana Oliveira",
                CPF = "588.408.970-89",
                Identificador = Guid.NewGuid(),
                Profissao = "Professor",
                Id = 4
            },
            Agencia = new Agencia
            {
                Nome = "Agência Nova Era",
                Identificador = Guid.NewGuid(),
                Id = 3,
                Endereco = "Praça Central",
                Numero = 789
            }
        }
    };

    public List<ContaCorrente> ContasCorrente => _contaCorrentes;

    public bool AddClient(Cliente client)
    {
        try
        {
            Clients.Add(client);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool AddAgencia(Agencia agencia)
    {
        try
        {
            Agencias.Add(agencia);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool AddContaCorrente(ContaCorrente contaCorrente)
    {
        try
        {
            ContasCorrente.Add(contaCorrente);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<Cliente> GetClients()
    {
        return Clients;
    }

    public List<Agencia> GetAgencias()
    {
        return Agencias;
    }

    public List<ContaCorrente> GetContasCorrente()
    {
        return ContasCorrente;
    }
}