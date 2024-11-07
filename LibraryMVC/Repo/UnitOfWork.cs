using System;
using LibraryMVC.Data;

namespace LibraryMVC.Repo;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _dbContext;
    public UnitOfWork(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync()
    {
        await _dbContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
