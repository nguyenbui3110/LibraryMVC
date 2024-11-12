using Microsoft.AspNetCore.Identity;

namespace LibraryMVC.Entity;

public class Borrower : IdentityUser<int>
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public ICollection<BorrowingHistory> BorrowingHistories { get; set; }
}