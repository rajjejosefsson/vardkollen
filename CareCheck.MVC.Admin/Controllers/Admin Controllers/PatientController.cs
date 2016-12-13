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
            var viewModel = new PatientViewModel
            {
                Patients = _kommunWcfClient.PatientList()
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatient(PatientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var patient = new Patient
                {
                    Id = viewModel.Id,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    PersonNumber = viewModel.PersonNumber,
                    PhoneNumber = viewModel.PhoneNumber,
                    Adress = viewModel.Adress,
                    ZipCode = viewModel.ZipCode,
                };

                _kommunWcfClient.InsertOrUpdatePatient(patient);

                return RedirectToAction("Index");
            }
            // Temp: Redirect with patients
            viewModel.Patients = _kommunWcfClient.PatientList();
            return View("Index", viewModel);
        }




        [HttpPost]
        public ActionResult DeletePatient(int id)
        {
            _kommunWcfClient.DeletePatient(id);
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