using System.ComponentModel.DataAnnotations;

namespace CMS.Web.Models.User;  
public class LoginViewModel
{       
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

}
