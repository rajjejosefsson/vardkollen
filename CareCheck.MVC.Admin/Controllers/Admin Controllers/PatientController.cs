using AutoMapper;
using CareCheck.DomainClasses;
using CareCheck.MVC.Admin.KommunWebservice;
using CareCheck.MVC.Admin.ViewModels;
using System.Web.Mvc;

namespace CareCheck.MVC.Admin.Controllers.Admin_Controllers
{
    /* Contains the Patient Form and the Patient Table */
    public class PatientController : Controller
    {
        private readonly KommunWebserviceClient _kommunWcfClient = new KommunWebserviceClient();


        public ActionResult Index()
        {
            var viewModel = new CreatePatientViewModel
            {
                Patients = _kommunWcfClient.PatientList()
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatient(CreatePatientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                /* Auto maps eg. FirstName = viewModel.FirstName ect, */
                var patient = Mapper.Map<CreatePatientViewModel, Patient>(viewModel);

                _kommunWcfClient.InsertOrUpdatePatient(patient);

                TempData["IsSuccess"] = true;
                return RedirectToAction("Index");
            }
            // Temp: Redirect with patients
            viewModel.Patients = _kommunWcfClient.PatientList();
            return View("Index", viewModel);
        }


        [HttpPost]
        public ActionResult DeletePatient(int id)
        {
            _kommunWcfClient.DeletePatientById(id);
            return RedirectToAction("Index");
        }


        public ActionResult RelativeConnection()
        {
            var patients = _kommunWcfClient.PatientList();
            var relatives = _kommunWcfClient.RelativeList();

            var viewModel = new PatientsAndRelativesViewModel
            {
                Patients = patients,
                Relatives = relatives,
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult CreateConnection(PatientsAndRelativesViewModel viewModel)
        {
            _kommunWcfClient.ConnectRelativeAndPatient(viewModel.PatientId, viewModel.RelativeId);
            return RedirectToAction("RelativeConnection");
        }
    }
}