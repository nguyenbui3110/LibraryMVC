namespace LibraryMVC.Models;

public interface IPagingItem
{
    public int CurrentPage { get; set; }
    public int CountPages { get; set; }

    public Func<int, string> PageUrl { get; set; }
}