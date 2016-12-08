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
                // if using create or edit
                if (viewModel.Id == 0)
                {
                    // CREATE Employee

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
                }
                else
                {
                    // EDIT Employee

                    var patientInDb = _context.Patients.Single(e => e.Id == viewModel.Id);

                    patientInDb.FirstName = viewModel.FirstName;
                    patientInDb.LastName = viewModel.LastName;
                    patientInDb.PersonNumber = viewModel.PersonNumber;
                    patientInDb.PhoneNumber = viewModel.PhoneNumber;
                    patientInDb.Adress = viewModel.Adress;
                    patientInDb.ZipCode = viewModel.ZipCode;
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Temp send back when not valid
            viewModel.Patients = _context.Patients.ToList();
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










        // OLD BACKUP
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatientOld(PatientViewModel viewModel)
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





    }
}