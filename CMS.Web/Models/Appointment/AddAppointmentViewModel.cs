using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace CMS.Web.Models.Appointment;

public class AddAppointmentViewModel
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string UserName { get; set; }
  
  [System.ComponentModel.DisplayName("Scheduled For")]
  public DateOnly Date { get; set; }
    
  [System.ComponentModel.DisplayName("Time")]
  public TimeOnly Time { get; set; }
  public SelectList Patients { set; get; }
  [Required]
  [Display(Name = "Select Patient")]
  public int PatientId { get; set; }
  public SelectList Users { set; get; }
  [Required]
  [Display(Name = "Select User")]
  public int UserId { get; set; }

  // Foreign key relating to patient and User


  // public Patient Patient { get; set; } 
  // // navigation property
  // public User User { get; set; }
}

