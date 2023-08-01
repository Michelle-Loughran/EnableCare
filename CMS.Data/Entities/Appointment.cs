using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace CMS.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set;}

        public DateTime Completed {get; set; }
              
        // Foreign keys the appointment related to the patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }       

    }
}

