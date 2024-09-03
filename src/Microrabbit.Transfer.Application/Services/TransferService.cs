using MicroRabbit.Domain.Core.Bus;
using Microrabbit.Transfer.Application.Interfaces;
using Microrabbit.Transfer.Domain.Interfaces;
using Microrabbit.Transfer.Domain.Models;

namespace Microrabbit.Transfer.Application.Services;

public class TransferService : ITransferService
{
    private readonly IEventBus _eventBus;
    private readonly ITransferRepository _transferRepository;

    public TransferService(ITransferRepository transferRepository, IEventBus eventBus)
    {
        _transferRepository = transferRepository;
        _eventBus = eventBus;
    }

    public IEnumerable<TransferLog> GetTransferLogs()
    {
        return _transferRepository.GetTransfersLogs();
    }
}