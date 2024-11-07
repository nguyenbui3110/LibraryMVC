using LibraryMVC.Data;
using LibraryMVC.Entity;
using LibraryMVC.Repo;
using LibraryMVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Extensions;

public static class ServiceExtentions
{

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ILibraryService, LibraryService>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
    
    public static IServiceCollection AddRepositorys(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepo<>), typeof(RepoBase<>));
        services.AddScoped<LibraryRepo>();
        services.AddScoped<RepoBase<LibraryItem>>();
        return services;
    }
    
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<Borrower, IdentityRole<int>>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.SignIn.RequireConfirmedAccount = false;
        }).AddEntityFrameworkStores<LibraryDbContext>().AddDefaultTokenProviders();
        
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/login";
            options.AccessDeniedPath = "/";
            options.LogoutPath = "/logout";
            options.ReturnUrlParameter= String.Empty;
        });
        return services;
    }
    
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
    
}
