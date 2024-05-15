using LemonadeStand.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LemonadeStand.Application.Test
{
    public class TestFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public TestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<OrderValidator>();
            serviceCollection.AddScoped<IFruitPressService, FruitPressService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
