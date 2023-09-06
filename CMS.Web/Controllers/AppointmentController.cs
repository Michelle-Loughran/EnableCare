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
    [Authorize(Roles="manager")]   
    public IActionResult AddAppointment()
    {       
            var users =svc.GetAllCarers();
            var patients = svc.GetAllPatients();
            if (users == null || patients == null)
            {
                Alert("Please check there are users and patients!", AlertType.warning);
                return RedirectToAction(nameof(Index));   
            }   
            // display blank form to create an appointment
            var avm = new AddAppointmentViewModel
            {
                Patients = new SelectList(patients,"Id","Patient.Name"),
                Users = new SelectList(users,"Id","User.Name"),

            };

            //return the new Patient care-event to the view
            return View(avm);
    }
  // POST: /patientcareevent/schedule/patientId   
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddAppointment([Bind("Name, UserName, Date, Time, PatientId, UserId")] AddAppointmentViewModel app)

        {    // Check patient care event being passed in has Id preset before adding propertie
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    Name = app.Name,
                    UserName = app.UserName,
                    Date = app.Date,
                    Time = app.Time,
                    UserId = app.UserId,
                    PatientId = app.PatientId,     

                };
                // call service Addpatientcareevent method using data in pce
                svc.AddAppointment(appointment);
                
                Alert("Adding Appointment was scheduled successfully!", AlertType.warning);

                return RedirectToAction(nameof(AppointmentDetails), new { Id = app.Id });
            }
            // initialise the selectlist
            var users = svc.GetAllCarers();
            app.Users = new SelectList(users,"Id","User.Name");  

            var patients = svc.GetAllPatients();
            app.Patients= new SelectList(patients,"Id","Name");  

            // if null, redirect to index
            if (users == null || patients == null)
            {
                Alert("Appointment was NOT added, there is a problem", AlertType.warning);
                return RedirectToAction(nameof(Index));   
            }

            // Redisplay for editing if it contains errors
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

        var avm = new AppointmentViewModel
        {
            Date = appointment.Date,
            Time = appointment.Time,
            Name = appointment.Name,
            PatientId = appointment.PatientId,
            UserId = appointment.UserId
        };
        var patients = svc.GetAllPatients();
        avm.Patients = new SelectList(patients, "Id", "Patient.Name");
        var users = svc.GetAllCarers();
        avm.Users = new SelectList(users, "Id", "User.Name");
        // pass appointment to view for editing
        return View("EditAppointment",(avm));
    }
    
    [Authorize(Roles="carer, manager")]
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

