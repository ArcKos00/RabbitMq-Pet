using Banking.Domain.CommandHandlers;
using Banking.Domain.Commands;
using Domain.Core.Bus;
using Infrastructure.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            return services;
        }
    }
}
