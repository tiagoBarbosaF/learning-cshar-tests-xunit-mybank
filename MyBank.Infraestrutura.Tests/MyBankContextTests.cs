using MyBank.Dados.Contexto;

namespace MyBank.Infraestrutura.Tests;

public class MyBankContextTests
{
    private ByteBankContexto _contexto = new();
    
    [Fact]
    public void TestContextConectionWithDB()
    {
        bool connect;

        try
        {
            connect = _contexto.Database.CanConnect();
        }
        catch (Exception e)
        {
            throw new Exception("Não foi possível conectar a base de dados.");
        }
        
        Assert.True(connect);
    }
}