using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Data.Entities;
using CMS.Data.Services;
using CMS.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Web.Controllers
{
    [Authorize]
    public class PatientCareEventController : BaseController
    {
        private readonly IPatientService svc;

        public PatientCareEventController()
        {
            svc = new PatientServiceDb();
        }

        public IActionResult Index()
        {
            // load patientcare-events using service and pass to view
            var pce = svc.GetAllPatientCareEvents();

            return View(pce);
        }

        // GET /Patient Care Event/details/{id}
        public IActionResult Details(int id)
        {
            var pce = svc.GetPatientCareEventById(id);

            // check if patientcare-events is null and alert/redirect 
            if (pce is null)
            {
                Alert("Patient Care Event Does not Exist", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            return View(pce);
        }

        // GET: /patientcareevent/create/patientId   
        [Authorize(Roles="carer, manager")]
        public IActionResult Create(int patientId)
        {
            var patient = svc.GetPatientById(patientId);
            if (patient is null)
            {
                Alert("Patient does not exist", AlertType.warning);
                return RedirectToAction(nameof(Index), "Patient");
            }

            var userId = User.GetSignedInUserId();

            var carer = svc.GetCarerByUserId(userId);
            if (carer is null)
            {
                Alert("Carer does not exist", AlertType.warning);
                return RedirectToAction(nameof(Details), "Patient", new { Id = patientId });
            }        

            // display blank form to create a carer
            var pce = new PatientCareEvent
            {
                Patient = patient,
                PatientId = patient.Id,                
                Carer = carer,
                CarerId = carer.Id,
                CarePlan = patient.CarePlan,
                DateTimeOfEvent = DateTime.Now,
                Issues = "record visit activity here...",
                
            };

            //return the new Patient care-event to the view
            return View(pce);
        }

        // POST /carers/create
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(int patientId, [Bind("DateTimeOfEvent, CarePlan, Issues, PatientId, CarerId")] PatientCareEvent pce)
        {    // Check patient care event being passed in has Id preset before adding properties
            if (pce == null)
            {
                Alert($"Patient Care Event Does not exist {pce.Id}", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            // complete POST action to add patient care event to database
            if (ModelState.IsValid)
            {
                // call service Addpatientcareevent method using data in pce
                svc.AddPatientCareEvent(pce);

                Alert("Patient-care-event created successfully!", AlertType.warning);

                return RedirectToAction(nameof(Details), "Patient", new { Id = pce.PatientId });
            }

            // redisplay the form for editing as there are validation errors
            return View(pce);
        }

        // GET /PatientCareEvent/Delete/{id}
        public IActionResult Delete(int id)
        {
            var pce = svc.GetPatientCareEventById(id);

            // check if patientcare-events is null and alert/redirect 
            if (pce is null)
            {
                Alert("Patient Care Event Does not Exist", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            return View(pce);
        }

        // POST /PatientCareEvent/Delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var ce = svc.GetPatientCareEventById(id);
            if (ce is null) 
            {
                Alert("Patient Care Event Could not be deleted", AlertType.warning); 
            }
           svc.DeletePatientCareEvent(id);           

           return RedirectToAction("Details", "Patient", new { id = ce.PatientId });
        }

    }
}
