using MicroRabbit.Domain.Core.Bus;
using Microrabbit.Transfer.Domain.Events;
using Microrabbit.Transfer.Domain.Interfaces;
using Microrabbit.Transfer.Domain.Models;

namespace Microrabbit.Transfer.Domain.EventHandler;

public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
{
    private readonly ITransferRepository _transferRepository;

    public TransferEventHandler(ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    public Task Handle(TransferCreatedEvent @event)
    {
        _transferRepository.Add(new TransferLog
        {
            FromAccount = @event.From,
            ToAccount = @event.To,
            TransferAmount = @event.Amount
        });

        return Task.CompletedTask;
    }
}