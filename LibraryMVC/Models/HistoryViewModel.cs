using LibraryMVC.Entity.Enum;

namespace LibraryMVC.Models;

public class HistoryViewModel
{
    public int Id { get; set; }
    public int BorrowerId { get; set; }
    public string BorrowerName { get; set; }
    public int LibraryItemId { get; set; }
    public LibraryItemModel? LibraryItem { get; set; }
    public DateTime? BorrowDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public BorrowingHistoryStatus Status { get; set; }
}