using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using CMS.Data.Entities;
using CMS.Data.Services;
using Microsoft.AspNetCore.Authorization;
using CMS.Data.Security;
using CMS.Web.Models.User;
using System;


namespace CMS.Web.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IPatientService svc;

        public AppointmentController()
        {
            svc = new PatientServiceDb();
        }

        public IActionResult Index()
        {
            IList<Appointment> appointments;
            if (User.HasOneOfRoles("carer"))
            {
                appointments = svc.GetUserAppointments(User.GetSignedInUserId());
            }
            else
            {
                // load appointments using service and pass to view
                appointments = svc.GetAllAppointments();
            }

            return View(appointments);
        }

        // GET /patient/details/{id}
        public IActionResult Details(int id)
        {
            // retrieve the patient with specified id from the service
            var patient = svc.GetPatientById(id);

            // check if patient is null and alert/redirect 
            if (patient == null)
            {
                Alert("Patient Does not Exist", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }
    }
}