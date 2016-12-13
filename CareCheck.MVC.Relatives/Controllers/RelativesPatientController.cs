using CareCheck.MVC.Relatives.RelativesWebservice;
using CareCheck.MVC.Relatives.ViewModels;
using System.Web.Mvc;

namespace CareCheck.MVC.Relatives.Controllers
{

    /* View of the relatives patient (Should be restricted for relatives) */
    public class RelativesPatientController : Controller
    {


        private readonly RelativesWebserviceClient _relativesWcfClient = new RelativesWebserviceClient();



        public ActionResult Index()
        {
            // Change to get by email instead
            var relative = _relativesWcfClient.RelativesPatientByEmail("0734214122");


            var viewModel = new PatientAndScheduleViewModel
            {
                Relative = relative,
                Patients = relative.Patients,
            };

            return View(viewModel);
        }


        // Partialview with all relative information
        public ActionResult PatientInformation(int id)
        {
            var patient = _relativesWcfClient.PatientDetailInfoById(id);
            var schedule = _relativesWcfClient.PatientDetailSchedules(id);

            var viewModel = new PatientAndScheduleViewModel
            {
                Patient = patient,
                Schedules = schedule,
            };
            return PartialView("_PatientInfoPartialView", viewModel);
        }

    }
}






