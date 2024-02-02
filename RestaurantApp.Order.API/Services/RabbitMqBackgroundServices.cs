
using MassTransit;

namespace RestaurantApp.Order.API.Services;


/*public class RabbitMqBackgroundServices : BackgroundService
{
    private readonly IBusControl _busControl;

    public RabbitMqBackgroundServices(IBusControl busControl)
    {
        _busControl = busControl;
    }


    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return _busControl.StartAsync(stoppingToken);
    }


    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await _busControl.StopAsync(cancellationToken);
        await base.StopAsync(cancellationToken);
    }
}*/