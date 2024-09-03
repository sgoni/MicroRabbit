using Microrabbit.Transfer.Domain.Models;

namespace Microrabbit.Transfer.Application.Interfaces;

public interface ITransferService
{
    IEnumerable<TransferLog> GetTransferLogs();
}