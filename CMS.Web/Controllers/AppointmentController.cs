using Microsoft.AspNetCore.Mvc;

using CMS.Data.Entities;
using CMS.Data.Services;
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
        [Authorize(Roles = "manager")]
        public IActionResult AddAppointment()
        {
            // display blank form to create a patient
            var app = new Appointment();
            //return the new patient to the view
            return View(app);
        }

//     // GET: /appointment/create
// [Authorize(Roles="manager")]   
//     public IActionResult AddAppointment(int id)
//     {
//             var patient = svc.GetPatientById(id);
//             if (patient is null)
//             {
//                 Alert("Patient does not exist", AlertType.warning);
//                 return RedirectToAction(nameof(Index), "Appointment");
//             }
//             // display blank form to create an appointment
//             var pce = new Appointment
//             {
//                 Patient = patient,
//                 PatientId = patient.Id,  
//                 Date = new DateTime(),
//                 Time = new TimeOnly()
             
//             };

//             //return the new Patient care-event to the view
//             ViewBag.Carers = new SelectList(svc.GetAllCarers(),"Id","Name");
//             ViewBag.Patients = new SelectList(svc.GetAllPatients(),"Id","Name");
//             return View(pce);
// }
// //   // POST: /patientcareevent/schedule/patientId   
//         [ValidateAntiForgeryToken]
//         [HttpPost]
//         [Authorize(Roles="manager")]
//         public IActionResult AddAppointment(int patientId, [Bind("Date, Time, PatientId, UserId")] Appointment app)
//         {    // Check patient care event being passed in has Id preset before adding properties
//             if (app == null)
//             {
//                 Alert($"Appointment Does not exist {app.Id}", AlertType.warning);
//                 return RedirectToAction(nameof(Index));
//             }

//             // complete POST action to add patient care event to database
//             if (ModelState.IsValid)
//             {
//                 // call service AddAppointment method using data in app
//                 svc.AddAppointment(app);

//                 Alert("Appointment scheduled successfully!", AlertType.warning);

//                 return RedirectToAction(nameof(Index), "Appointment", new { Id = app.PatientId });
//             }

//             // redisplay the form for editing as there are validation errors
//             return View(app);
//         }

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
