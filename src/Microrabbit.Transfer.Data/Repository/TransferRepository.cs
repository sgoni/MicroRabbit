using Microrabbit.Transfer.Data.Context;
using Microrabbit.Transfer.Domain.Interfaces;
using Microrabbit.Transfer.Domain.Models;

namespace Microrabbit.Transfer.Data.Repository;

public class TransferRepository : ITransferRepository
{
    private readonly TransferDBContext _dbContext;

    public TransferRepository(TransferDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(TransferLog transferLog)
    {
        _dbContext.TransferLogs.Add(transferLog);
        _dbContext.SaveChanges();
    }

    public IEnumerable<TransferLog> GetTransfersLogs()
    {
        return _dbContext.TransferLogs;
    }
}