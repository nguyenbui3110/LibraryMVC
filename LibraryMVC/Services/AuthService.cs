using System;
using LibraryMVC.Constants;
using LibraryMVC.Entity;
using LibraryMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryMVC.Services;


public interface IAuthService
{
    public Task<bool> RegisterAsync(RegisterModel model);
    public Task<bool> LoginAsync(LoginModel model);
    public Task LogoutAsync();
    public Task<Borrower> GetUserAsync();
    
}

public class AuthService : IAuthService
{
    private readonly UserManager<Borrower> _userManager;
    private readonly SignInManager<Borrower> _signInManager;

    public AuthService(UserManager<Borrower> userManager, SignInManager<Borrower> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public Task<Borrower> GetUserAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> LoginAsync(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if(user == null)
        {
            return false;
        }
        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
        if (!result.Succeeded)
        {
            // throw new Exception("Invalid login attempt");
            return false;
        }
        return true;


    }
    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }


    public async Task<bool> RegisterAsync(RegisterModel model)
    {
        var user = new Borrower
        {
            UserName = model.Username,
            Email = model.Email,
            LibraryCardId = Guid.NewGuid()
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            user= await _userManager.FindByNameAsync(model.Username);
            user.EmailConfirmed = true;
             var addRoleResult = await _userManager.AddToRoleAsync(user, AppRole.User);
            if (!addRoleResult.Succeeded)
                return false;
            await _signInManager.SignInAsync(user, false);
            return true;
        }
        return false;
        
    }
}
