using LibraryMVC.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Data;

public class LibraryDbContext:IdentityDbContext<Borrower,IdentityRole<int>,int>
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }
    public DbSet<LibraryItem> LibraryItems { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Magazine> Magazines { get; set; }
    public DbSet<BorrowingHistory> BorrowingHistories { get; set; }
    public DbSet<Dvd> Dvds { get; set; }
    
    protected override void OnModelCreating (ModelBuilder builder) {
        builder.AddIdentitySeedData();
        builder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
        base.OnModelCreating (builder); 
        // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
        // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
        // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
    } 
}