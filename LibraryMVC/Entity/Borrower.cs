namespace LibraryMVC.Entity;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class Borrower : IdentityUser<int>
{
    public string Name { get; set; }
    public string Address { get; set; }
    [Key]
    public Guid LibraryCardId { get; set; }
    public ICollection<BorrowingHistory> BorrowingHistories { get; set; }
}