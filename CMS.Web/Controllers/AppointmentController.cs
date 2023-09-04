using Microsoft.AspNetCore.Mvc;

using CMS.Data.Entities;
using CMS.Data.Services;
using CMS.Web.Models.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMS.Web.Controllers
{
    [Authorize]
    public class AppointmentController : BaseController
    {
        private readonly IPatientService svc;

        public AppointmentController()
        {
            svc = new PatientServiceDb();
        }

        [Authorize(Roles = "admin, manager")]
        public IActionResult Index()
        {
            // load appointments using service and pass to view

            var app = svc.GetAllAppointments();

            return View(app);
        }

        // GET: /appointment/add-appointment/id   
        // [Authorize(Roles = "manager")]
        // public IActionResult AddAppointment()
        // {
        //     // display blank form to create a patient
        //     var app = new Appointment();
        //     //return the new patient to the view
        //     return View(app);
        // }

//     // GET: /appointment/create
[Authorize(Roles="manager")]   
    public IActionResult AddAppointment(int id)
    {       
            var users =svc.GetAllCarers();
            var user =svc.GetCarerByUserId(id);
            var patients = svc.GetAllPatients();
            var patient = svc.GetPatientById(id);
            if (patient == null)
            {
                Alert("Patient does not exist", AlertType.warning);
                return RedirectToAction(nameof(Index), "Appointment");
            }
            // display blank form to create an appointment
            var avm = new AppointmentViewModel
            {
                Patients = new SelectList(patients,"Id","Name"),
                Users = new SelectList(users,"Id","Name"),
                PatientId = patient.Id,
                Name = patient.Name,
                UserName = user.Name,
                Date = new DateOnly(),
                Time = new TimeOnly()
            };

            //return the new Patient care-event to the view
            return View("AddAppointment",avm);
}
// //   // POST: /patientcareevent/schedule/patientId   
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles="admin, manager")]
        public IActionResult AddAppointment([Bind("Date, Name, Time, PatientId, UserId")] AppointmentViewModel app, int id)
        {    // Check patient care event being passed in has Id preset before adding properties
            var user = svc.GetCarerByUserId(app.UserId);
            var patient = svc.GetPatientById(app.PatientId);
            if (patient == null)
            {
                Alert("Patient does not exist", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            
            // complete POST action to add patient care event to database
            if (ModelState.IsValid)
            {
                // call service AddAppointment method using data in app
                var appointment = new Appointment {
                    Patient = patient,
                    PatientId = app.PatientId,
                    User = user,
                    UserId = app.UserId,
                    Date = app.Date,
                    Time = app.Time,
                };  

                Alert("Appointment scheduled successfully!", AlertType.warning);

                return RedirectToAction("AppointmentDetails","Appointment", new { Id = app.PatientId });
            }

            // redisplay the form for editing as there are validation errors
            return View(app);
        }

 // GET /Carer/edit/{id}
    public IActionResult EditAppointment(int id)
    {
        // load the Carer using the service
        var appointment = svc.GetAppointmentById(id);

        // check if Carer is null and Alert/Redirect
        if (appointment is null)
        {
            Alert("Appointment not found", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }  

        // pass patient to view for editing
        return View(appointment);
    }
    
    [Authorize(Roles="carer, manager")]
    public IActionResult AppointmentDetails()
    {
        // user will be a manager or a carer
        var userId = User.GetSignedInUserId();

        var scheduled = svc.GetScheduledPatientCareEventsForUser(userId);
            
        return View(scheduled);
    }
            // GET /PatientCareEvent/Delete/{id}
        public IActionResult Delete(int id)
        {
            var app = svc.GetAppointmentById(id);

            // check if appointment is null and alert/redirect 
            if (app is null)
            {
                Alert("Appointment Does not Exist", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            return View(app);
        }
        // POST /PatientCareEvent/Delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var ap = svc.GetAppointmentById(id);
            if (ap is null)
            {
                Alert("Appointment Could not be deleted", AlertType.warning);
            }

            svc.DeleteAppointment(id);

            return RedirectToAction("Index", "Appointment", new { id = ap.Id });
        }

    }
}
