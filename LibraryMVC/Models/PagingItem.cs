namespace LibraryMVC.Models;

public class PagingItem<T> : IPagingItem
{
    public int pageSize { get; set; } = 8;
    public List<T> Items { get; set; }
    public int CurrentPage { get; set; }
    public int CountPages { get; set; }

    public Func<int, string> PageUrl { get; set; } = i => $"?page={i}";

    public void ApplyPaging()
    {
        CountPages = (int)Math.Ceiling(Items.Count() / (double)pageSize);
        Items = Items
            .Skip((CurrentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}