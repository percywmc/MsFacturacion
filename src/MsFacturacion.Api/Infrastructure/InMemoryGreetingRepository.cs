using MsFacturacion.Api.Domain;

namespace MsFacturacion.Api.Infrastructure;

public class InMemoryGreetingRepository : IGreetingRepository
{
    public Greeting GetGreeting()
    {
        return new Greeting { Message = "API is running" };
    }
}
