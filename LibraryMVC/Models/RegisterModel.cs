using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models;

public class RegisterModel
{
    public string Username { get; set; }

    [DataType(DataType.Password)] public string Password { get; set; }

    [DataType(DataType.Password)] public string ConfirmPassword { get; set; }

    [DataType(DataType.EmailAddress)] public string Email { get; set; }
}