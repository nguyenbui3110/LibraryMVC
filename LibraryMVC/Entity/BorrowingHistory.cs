using LibraryMVC.Entity.Enum;

namespace LibraryMVC.Entity;

public class BorrowingHistory
{
    public int Id { get; set; }
    public Guid LibraryCardId { get; set; }
    public Borrower? Borrower { get; set; }
    public int LibraryItemId { get; set; }
    public LibraryItem? LibraryItem { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public BorrowingHistoryStatus Status { get; set; }
}