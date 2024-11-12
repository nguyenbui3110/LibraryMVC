using LibraryMVC.Data;
using LibraryMVC.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Repo;

public class BorrowingHistoryRepo : RepoBase<BorrowingHistory>
{
    public BorrowingHistoryRepo(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<BorrowingHistory>> GetBorrowingHistoryByUserIdAsync(int userId)
    {
        return await _dbContext.BorrowingHistories.Include(h => h.LibraryItem)
            .Where(history => history.BorrowerId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<BorrowingHistory>> GetBorrowingHistoryAsync()
    {
        return await _dbContext.BorrowingHistories.Include(history => history.Borrower).Include(h => h.LibraryItem)
            .Include(h => h.Borrower)
            .ToListAsync();
    }

    public async Task<IEnumerable<LibraryItem?>> GetUserBorrowingLibraryItemsAsync(int userId, int itemId)
    {
        return await _dbContext.BorrowingHistories
            .Include(history => history.LibraryItem)
            .Where(history => history.BorrowerId == userId && history.LibraryItem.Id == itemId)
            .Select(history => history.LibraryItem).ToListAsync();
    }
}