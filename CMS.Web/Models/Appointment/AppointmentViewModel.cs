using CMS.Data.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;
using CMS.Data.Entities;
using System.ComponentModel;

namespace CMS.Web.Models.Appointment;

public class AppointmentViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    [DisplayName("Scheduled For")]
    public DateOnly Date { get; set; }
    
    [DisplayName("Time")]
    public TimeOnly Time { get; set; }
        
    [DisplayName("Scheduled For")]
    public DateTime DateTimeOfEvent { get; set; } = DateTime.Now;

    [DateGreaterThan("DateTimeOfEvent")]
    [DisplayName("Completed On")]
    public DateTime DateTimeCompleted { get; set; } = DateTime.MinValue;
    public SelectList Patients { set; get; }
    public SelectList Users { set; get; }
    // Foreign key relating to patient and User
    public int PatientId { get; set; }
    public int UserId { get; set; }
[DisplayName("Scheduled Length")]
  public int ScheduledDuration { get; set; } = 30;




    public Patient Patient { get; set; } 
    // // navigation property
    // public User User { get; set; }
}

