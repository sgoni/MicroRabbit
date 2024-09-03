using Microrabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Microrabbit.Transfer.Data.Context;

public class TransferDBContext : DbContext
{
    public TransferDBContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TransferLog> TransferLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(
                "Server=PC-MSI-B550;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}