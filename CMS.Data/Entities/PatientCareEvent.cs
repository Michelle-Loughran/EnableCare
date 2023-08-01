using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.Entities;

public class PatientCareEvent 
{
    public int Id { get; set; }

    public DateTime DateTimeOfEvent { get; set; } = DateTime.Now;

    public DateTime? DateTimeCompleted { get; set; } = null; //DateTime.MinValue;

    // copy of Patient.CarePlan made when Event created
    public string CarePlan { get; set; } 

    // Notes documenting completion of Careplan
    public string Issues { get; set; }

    // relationships

    // the patient the care event is performed on
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    
    // the carer who performed the care event
    public int CarerId { get; set; }
    public User Carer { get; set; }


}

