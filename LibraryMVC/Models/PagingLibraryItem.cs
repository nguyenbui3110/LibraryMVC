using System;

namespace LibraryMVC.Models;

public class PagingLibraryItem
{
    public int CurrentPage { get; set; }
    public int CountPages { get; set; }
    
    public Func<int, string> PageUrl { get; set; }= i=> $"?page={i}";
    public List<LibraryItemModel> LibraryItems { get; set; }

}
