using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMS.Data.Validators;
namespace CMS.Data.Entities;

public class Appointment
{
  public int Id { get; set; }
     
  [System.ComponentModel.DisplayName("Scheduled For")]
  public DateOnly Date { get; set; }
    
  [System.ComponentModel.DisplayName("Time")]
  public TimeOnly Time { get; set; }
  // [System.ComponentModel.DisplayName("Scheduled Length")]

  // public int ScheduledDuration { get; set; } = 30;
  
  public DateTime DateTimeCompleted { get; set; }

  // Foreign key relating to patient and User
  public int PatientId { get; set; }
  public int UserId { get; set; }

  public Patient Patient { get; set; } // navigation property
  public User User { get; set; } // navigation property


}

