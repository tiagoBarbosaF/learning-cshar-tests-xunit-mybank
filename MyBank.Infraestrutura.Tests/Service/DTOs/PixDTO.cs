namespace MyBank.Infraestrutura.Tests.Service.DTOs;

public class PixDTO
{
    private Guid _key;
    private double _saldo;

    public Guid Key
    {
        get => _key;
        set => _key = value;
    }

    public double Saldo
    {
        get => _saldo;
        set => _saldo = value;
    }
}