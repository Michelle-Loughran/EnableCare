using Microsoft.AspNetCore.Mvc;

using CMS.Data.Entities;
using CMS.Data.Services;
using CMS.Web.Models.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration.UserSecrets;

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
        public IActionResult AppointmentDetails(int id)
        {
            var appointment = svc.GetAppointmentById(id);

            // check if patientcare-events is null and alert/redirect 
            if (appointment is null)
            {
                Alert("Appointment Does not Exist", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            return View(appointment);
        }

        //     // GET: /appointment/create
        [Authorize(Roles = "manager")]
        public IActionResult AddAppointment(Appointment app)
        { 

            var patients = svc.GetAllPatients();
            var users = svc.GetAllCarers();

                        if (patients is null || users is null)
            {
                Alert("Patients or users do not exist", AlertType.warning);
                return RedirectToAction(nameof(Index), "Appointment");
            }  
     
        // display blank form to create appointment
        var ap = new Appointment
        {
            PatientId = app.PatientId,
            UserId = app.UserId,
        };
 
        //return the new appointment to the view
    
            ViewBag.Carers = new SelectList(svc.GetAllCarers(), "Id", "Name");
            ViewBag.Patients = new SelectList(svc.GetAllPatients(), "Id", "Name");
            //return the new Appointment to the view
            return View(app);
        }

        // POST: /patientcareevent/schedule/patientId   
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles="manager")]
        public IActionResult AddAppointment(int id, [Bind(" Date, Time, PatientId, UserId")] Appointment app)
        {
            // Check appointment being passed in has Id preset before adding properties
            if (app == null)

            {
                Alert($"Appointment Does not exist {app.Id}", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            // complete POST action to add appointment to database
            if (ModelState.IsValid)
            {
                // call service Addpatientcareevent method using data in pce
                svc.AddAppointment(app);

                Alert("Appointment scheduled successfully!", AlertType.warning);

                return RedirectToAction(nameof(AppointmentDetails), "Appointment", new { Id = app.Id });
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


            ViewBag.Carers = new SelectList(svc.GetAllCarers(), "Id", "Name");
            ViewBag.Patients = new SelectList(svc.GetAllPatients(), "Id", "Name");
            // pass appointment to view for editing
            return View(appointment);
        }

        [Authorize(Roles = "carer, manager")]
        public IActionResult MyAppointments()
        {
            // user will be a manager or a carer
            var userId = User.GetSignedInUserId();

            var scheduled = svc.GetAppointmentsForUser(userId);

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

