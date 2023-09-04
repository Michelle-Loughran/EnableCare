using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using CMS.Data.Validators;

namespace CMS.Web.Models.Appointment;

public class AppointmentViewModel
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string UserName { get; set; }
  [System.ComponentModel.DisplayName("Scheduled For")]
  public DateOnly Date { get; set; }
    
  [System.ComponentModel.DisplayName("Time")]
  public TimeOnly Time { get; set; }

  
// [System.ComponentModel.DisplayName("Scheduled Length")]
//
//   public int ScheduledDuration { get; set; } = 30;
  // public DateTime DateTimeOfEvent { get; set; } = DateTime.Now;
  // public DateTime DateTimeCompleted { get; set; }
  // public DateTime DateTimeOfEvent { get; set; } = DateTime.Now;
  public SelectList Patients { set; get; }
  public SelectList Users { set; get; }

  // Foreign key relating to patient and User
  public int PatientId { get; set; }
  public int UserId { get; set; }
  public Patient Patient { get; set; } 
  // navigation property
  public Data.Entities.User User { get; set; }
}

