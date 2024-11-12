namespace LibraryMVC.Common;

public interface IcurrentUser
{
    public string? UserId { get; }
    public string? UserName { get; }
    public bool? IsAuthenticated { get; }
}