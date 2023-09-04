using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CMS.Data.Entities;

public class Appointment
{
  public int Id { get; set; }
  public string Name { get; set; }
     
  [System.ComponentModel.DisplayName("Scheduled For")]
  public DateTime Date { get; set; }
    
  [System.ComponentModel.DisplayName("Time")]
  public TimeOnly Time { get; set; }
  
  // public DateTime DateTimeOfEvent { get; set; } = DateTime.Now;
  // public DateTime DateTimeCompleted { get; set; } = DateTime.MaxValue;

  // Foreign key relating to patient and User
  public int PatientId { get; set; }
  public int UserId { get; set; }

  public Patient Patient { get; set; } // navigation property
  public User User { get; set; } // navigation property


}

