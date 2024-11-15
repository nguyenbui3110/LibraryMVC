using LibraryMVC.Data;
using LibraryMVC.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Repo;

public class LibraryRepo : RepoBase<LibraryItem>
{
    public LibraryRepo(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<LibraryItem?> GetLibraryItemAsync(int id)
    {
        return await _dbContext.LibraryItems.FindAsync(id);
    }

    public async Task<IEnumerable<LibraryItem>> SearchLibraryItemAsync(string searchParam)
    {
        if (string.IsNullOrEmpty(searchParam)) return Enumerable.Empty<LibraryItem>();

        return await _dbContext.LibraryItems
            .Where(item => item.Title.Contains(searchParam) || item.Author.Contains(searchParam))
            .OrderByDescending(item => item.Quantity)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _dbContext.Books.OrderByDescending(b => b.Quantity).ToListAsync();
    }

    public async Task<IEnumerable<Magazine>> GetMagazinesAsync()
    {
        return await _dbContext.Magazines.OrderByDescending(m => m.Quantity).ToListAsync();
    }

    public async Task<IEnumerable<Dvd>> GetDvdsAsync()
    {
        return await _dbContext.Dvds.OrderByDescending(d => d.Quantity).ToListAsync();
    }
}