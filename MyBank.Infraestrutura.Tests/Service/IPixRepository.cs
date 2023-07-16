using MyBank.Infraestrutura.Tests.Service.DTOs;

namespace MyBank.Infraestrutura.Tests.Service;

public interface IPixRepository
{
    public PixDTO? getPix(Guid key);
}