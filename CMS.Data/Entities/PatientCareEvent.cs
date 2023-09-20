using System.ComponentModel;
using CMS.Data.Validators;

namespace CMS.Data.Entities;

public class PatientCareEvent 
{
    public int Id { get; set; }
    public string PFName { get; set; }
    public string PSName { get; set; } 
    public string UFName { get; set; } 
    public string USName { get; set; } 

    [DisplayName("Scheduled For")]
    public DateTime DateTimeOfEvent { get; set; } = DateTime.Now;

    [DateGreaterThan("DateTimeOfEvent")]
    [DisplayName("Completed On")]
    public DateTime DateTimeCompleted { get; set; } = DateTime.MinValue;

    // copy of Patient.CarePlan made when Event created
    public string CarePlan { get; set; } 

    // Notes documenting completion of Careplan
    public string Issues { get; set; }

    // relationships

    // the patient the care event is performed on
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    
    // the carer who performed the care event
    public int UserId { get; set; }
    public User User { get; set; }



}

