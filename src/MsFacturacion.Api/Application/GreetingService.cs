using MsFacturacion.Api.Domain;

namespace MsFacturacion.Api.Application;

public class GreetingService : IGreetingService
{
    private readonly IGreetingRepository _repository;

    public GreetingService(IGreetingRepository repository)
    {
        _repository = repository;
    }

    public Greeting GetGreeting()
    {
        return _repository.GetGreeting();
    }
}
