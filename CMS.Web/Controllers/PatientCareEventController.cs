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


        [Authorize(Roles="admin, manager")]
        public IActionResult Index()
        {
            // load patientcare-events using service and pass to view
            
            var pce = svc.GetAllPatientCareEvents();

            return View(pce);
        }

        [Authorize(Roles="carer, manager")]

        public IActionResult Scheduled()
        {
            // user will be a manager or a carer
            var userId = User.GetSignedInUserId();

            var scheduled = svc.GetScheduledPatientCareEventsForUser(userId);
            
            return View(scheduled);
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

        // GET: /patientcareevent/schedule/patientId   
        [Authorize(Roles="carer, manager")]
        public IActionResult Schedule(int patientId)
        {
            var patient = svc.GetPatientById(patientId);
            if (patient is null)
            {
                Alert("Patient does not exist", AlertType.warning);
                return RedirectToAction(nameof(Index), "Patient");
            }

            var userId = User.GetSignedInUserId();

            var user = svc.GetCarerByUserId(userId);
            if (user is null)
            {
                Alert("Carer does not exist", AlertType.warning);
                return RedirectToAction(nameof(Details), "Patient", new { Id = patientId });
            }        

            // display blank form to create a carer
            var pce = new PatientCareEvent
            {
                Patient = patient,
                PatientId = patient.Id,                
                User = user,
                UserId = user.Id,
                CarePlan = patient.CarePlan,
                DateTimeOfEvent = DateTime.Now  
            };

            //return the new Patient care-event to the view
            return View(pce);
        }

        // POST: /patientcareevent/schedule/patientId   
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Schedule(int patientId, [Bind("DateTimeOfEvent, CarePlan, PatientId, UserId")] PatientCareEvent pce)
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
                svc.SchedulePatientCareEvent(pce);

                Alert("Patient-care-event scheduled successfully!", AlertType.warning);

                return RedirectToAction(nameof(Details), "Patient", new { Id = pce.PatientId });
            }

            // redisplay the form for editing as there are validation errors
            return View(pce);
        }


        // GET: /patientcareevent/complete/id   
        [Authorize(Roles="carer, manager")]
        public IActionResult Complete(int id)
        {
            var pce = svc.GetPatientCareEventById(id);
            if (pce is null)
            {
                Alert("Scheduled Care Event does not exist", AlertType.warning);
                return RedirectToAction(nameof(Index), "Patient");
            }            

            //return the new Patient care-event to the view
            return View(pce);
        }


        // POST /patientcareevent/complete/
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Complete(int id, [Bind("Id, DateTimeOfEvent, DateTimeCompleted, CarePlan, Issues, PatientId, UserId")] PatientCareEvent pce)
        {    
            // complete POST action to add patient care event to database
            if (ModelState.IsValid)
            {
                // hack to set complete time here - may want to collect input in form
                pce.DateTimeCompleted = DateTime.Now;

                // call service Addpatientcareevent method using data in pce
                svc.CompletePatientCareEvent(pce);

                Alert("Patient-care-event completed successfully!", AlertType.info);

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
