using System;
using LibraryMVC.Enums;

namespace LibraryMVC.Models;

public class LibraryItemModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Quantity { get; set; }
    public int NumberOfPages { get; set; }
    public string Runtime { get; set; }
    public ItemType Type { get; set; }
}
