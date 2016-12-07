using CareCheck.DataAccess;
using CareCheck.DomainClasses;
using System.Linq;
using System.Web.Mvc;
using vardkollen.ViewModels;

namespace vardkollen.Controllers
{
    public class PatientController : Controller
    {
        private readonly CareCheckDbContext _context = new CareCheckDbContext();

        public ActionResult Index()
        {
            var viewModel = new PatientViewModel
            {
                Patients = _context.Patients.ToList(),
            };

            return View(viewModel);
        }



        /* Used to get patients to the jquery datatables instead of render it with razor*/
        public ActionResult GetPatients()
        {
            var data = _context.Patients.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
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


                _context.Patients.Add(patient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", viewModel);
        }






        [HttpPost]
        public ActionResult DeletePatient(int id)
        {
            var patientInDb = _context.Patients.Single(e => e.Id == id);

            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}