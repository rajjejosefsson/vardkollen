using CareCheck.DomainClasses;
using System.Web.Mvc;
using vardkollen.KommunWebservice;
using vardkollen.ViewModels;

namespace vardkollen.Controllers
{
    public class PatientController : Controller
    {
        private readonly KommunWebserviceClient _kommunWcfClient = new KommunWebserviceClient();

        public ActionResult Index()
        {
            var viewModel = new PatientViewModel
            {
                Patients = _kommunWcfClient.PatientList(),
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







        /* BACKUP */
        /* Used to get patients to the jquery datatables instead of render it with razor*/
        /*
        public ActionResult GetPatients()
        {
            var data = _kommunWcfClient.PatientList(); ;
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        */


    }
}