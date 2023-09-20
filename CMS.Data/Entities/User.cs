using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.Entities;

// Add User roles relevant to your application
public enum Role { admin, manager, carer, family, guest }

public class User
{
    public int Id { get; set; }

    // general attributes of all users
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "First Name must be between 2 and 20 characters.", MinimumLength = 2)]
    [Display(Name = "First Name")]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "Surname must be between 2 and 20 charaters.", MinimumLength = 2)]
    [Display(Name = "Surname")]
    public string Surname { get; set; } = string.Empty;
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 4)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "Street must be between 2 and 20 characters.", MinimumLength = 2)]
    [Display(Name = "Street")]
    public string Street { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "Town must be between 2 and 20 characters.", MinimumLength = 2)]
    [Display(Name = "Town")]
    public string Town { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "County must be between 2 and 20 characters.", MinimumLength = 2)]
    [Display(Name = "County")]
    public string County { get; set; } = string.Empty;

    [Required]
    [StringLength(8, ErrorMessage = "Postcode must have 7 characters.", MinimumLength = 3)]
    public string Postcode { get; set; } = string.Empty;

    [Required]
    [StringLength(11, ErrorMessage = "MobileNumber must have 11 characters.", MinimumLength = 3)]
    public string MobileNumber { get; set; } = string.Empty;

   [Required]
    [StringLength(11, ErrorMessage = "HomeNumber must have 11 characters.", MinimumLength = 3)]
    public string HomeNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(12, MinimumLength = 8)]
    public string Password { get; set; }
    public Role Role { get; set; }
    public int UserId { get; set; }

    public string Name => Firstname + " " + Surname;
    public int Age => (DateTime.Now - DOB).Days / 365;


    // Properties relating to a Carer

    [StringLength(80, MinimumLength = 1)]
    public string NationalInsuranceNo { get; set; } = string.Empty;

    public bool DBSCheck { get; set; } = false;

    public string Qualifications { get; set; } = string.Empty;

    [Url]
    public string PhotoUrl { get; set; }

    public List<PatientCareEvent> CareEvents { get; set; }
    public List<PatientCondition> PatientConditions { get; set; }
    public List<FamilyMember> FamilyMembers { get; set; }
}

