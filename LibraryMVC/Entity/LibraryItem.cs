namespace LibraryMVC.Entity;

public class LibraryItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Quantity { get; set; }
    public ICollection<BorrowingHistory> BorrowingHistories { get; set; }
}