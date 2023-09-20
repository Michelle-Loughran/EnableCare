using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CMS.Data.Entities;

public class Patient

{    // primary key
    [Required]
    [Column("Patient_Id")]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "First Name must be between 2 and 20 characters.", MinimumLength = 2)]
    [Display(Name = "First Name")]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "Surname must be between 2 and 20 charaters.", MinimumLength = 2)]
    [Display(Name = "Surname")]
    public string Surname { get; set; } = string.Empty;
    public string Name => Firstname + " " + Surname;
    [Required]
    [StringLength(10, ErrorMessage = "National Insurance No Must have 10 characters.", MinimumLength = 2)]

    [Display(Name = "National Insurance No.")]
    public string NationalInsuranceNo { get; set; } = string.Empty;

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }
    // readonly
    public int Age => (DateTime.Now - DOB).Days / 365;

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

    [Url]
    public string PhotoUrl { get; set; }

    [Required]
    [StringLength(11, ErrorMessage = "MobileNumber must have 11 characters.", MinimumLength = 3)]
    public string MobileNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(11, ErrorMessage = "HomeNumber must have 11 characters.", MinimumLength = 3)]
    public string HomeNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "GP must be between 2 and 20 characters.", MinimumLength = 2)]
    [Display(Name = "GP")]
    public string GP { get; set; } = string.Empty;
    [Required]
    [StringLength(20, ErrorMessage = "SocialWorker must be between 2 and 20 characters.", MinimumLength = 2)]
    [Display(Name = "SocialWorker")]
    public string SocialWorker { get; set; } = string.Empty;
    [Required]
    [StringLength(500, ErrorMessage = "CarePlan needs between 2 and 20 characters.", MinimumLength = 2)]
    [Display(Name = "CarePlan")]
    public string CarePlan { get; set; }

    [Range(0, 10, ErrorMessage = "The number of calls should be between 1 and 10")]
    public int Calls { get; set; }
    public string Address => Street + " " + Town + " " + Postcode;

    // Relationships

    // a set of care events 
    public List<PatientCareEvent> CareEvents { get; set; }
    public List<PatientCondition> PatientConditions { get; set; }
    public List<FamilyMember> FamilyMembers { get; set; }


    public User User { get; set; } // navigation property

    // public int UserId { get; set; }

}
