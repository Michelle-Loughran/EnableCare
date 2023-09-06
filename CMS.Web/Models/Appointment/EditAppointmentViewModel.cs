using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CMS.Web.Models.Appointment;

public class EditAppointmentViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }

    [System.ComponentModel.DisplayName("Scheduled For")]
    public DateOnly Date { get; set; }

    [System.ComponentModel.DisplayName("Time")]
    public TimeOnly Time { get; set; }
    [Required]
    [Display(Name = "Select Patient")]
    public SelectList Patients { set; get; }
    [Required]
    [Display(Name = "Select User")]
    public SelectList Users { set; get; }

    // Foreign key relating to patient and User
    public int PatientId { get; set; }
    public int UserId { get; set; }
}