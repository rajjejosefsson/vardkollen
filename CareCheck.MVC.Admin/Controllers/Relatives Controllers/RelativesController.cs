using CareCheck.MVC.Admin.RelativesWebservice;
using CareCheck.MVC.Admin.ViewModels;
using System.Web.Mvc;

namespace CareCheck.MVC.Admin.Controllers.Relatives_Controllers
{

    /* View of the relatives patient (Should be restricted for relatives) */
    public class RelativesController : Controller
    {


        private readonly RelativesWebserviceClient _relativesWcfClient = new RelativesWebserviceClient();



        public ActionResult Index()
        {
            // Change to get by email instead
            var relative = _relativesWcfClient.RelativesPatientByEmail("ballan@gmail.com");


            var viewModel = new PatientAndScheduleViewModel
            {
                Relative = relative,
                Patients = relative.Patients,
            };

            return View(viewModel);
        }



        // Partialview with all relative information
        public ActionResult RelativeInformation(int id)
        {
            var patient = _relativesWcfClient.PatientDetailInfoById(id);
            var schedule = _relativesWcfClient.PatientDetailSchedules(id);

            var viewModel = new PatientAndScheduleViewModel
            {
                Patient = patient,
                Schedules = schedule,
            };
            return PartialView("_RelativePartialView", viewModel);
        }

    }
}











