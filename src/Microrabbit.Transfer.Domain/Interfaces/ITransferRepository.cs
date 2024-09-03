using Microrabbit.Transfer.Domain.Models;

namespace Microrabbit.Transfer.Domain.Interfaces;

public interface ITransferRepository
{
    IEnumerable<TransferLog> GetTransfersLogs();
    void Add(TransferLog transferLog);
}