using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data.Context;

public class BankingDBContext : DbContext
{
    public BankingDBContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(
                "Server=PC-MSI-B550;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}