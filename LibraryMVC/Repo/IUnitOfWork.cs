using System;

namespace LibraryMVC.Repo;

public interface IUnitOfWork
{
    public Task CommitTransactionAsync();
    public Task RollbackAsync();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public Task BeginTransactionAsync(CancellationToken cancellationToken = default);
}
