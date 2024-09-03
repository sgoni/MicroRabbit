﻿using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microrabbit.Transfer.Application.Interfaces;
using Microrabbit.Transfer.Application.Services;
using Microrabbit.Transfer.Data.Context;
using Microrabbit.Transfer.Data.Repository;
using Microrabbit.Transfer.Domain.EventHandler;
using Microrabbit.Transfer.Domain.Events;
using Microrabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC;

public class DepedencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        //Domain Bus
        services.AddSingleton<IEventBus, RabbitMQBus>(provider =>
        {
            var scopefactory = provider.GetRequiredService<IServiceScopeFactory>();
            return new RabbitMQBus(provider.GetService<IMediator>(), scopefactory);
        });

        //Subscriptions
        services.AddTransient<TransferEventHandler>();

        //Domain Events
        services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

        //Domian banking Commands
        services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

        //Application Services
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<ITransferService, TransferService>();

        //Data
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<ITransferRepository, TransferRepository>();
        services.AddTransient<BankingDBContext>();
        services.AddTransient<TransferDBContext>();
    }
}