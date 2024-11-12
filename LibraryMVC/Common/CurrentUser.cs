using System.Security.Claims;

namespace LibraryMVC.Common;

public class CurrentUser : IcurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public string? UserName => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);

    public bool? IsAuthenticated => _httpContextAccessor.HttpContext?.User.Identity.IsAuthenticated;
}