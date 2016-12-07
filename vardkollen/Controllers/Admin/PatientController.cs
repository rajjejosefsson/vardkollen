using CareCheck.DataAccess;
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
                FirstName = null,
                LastName = null,
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
                //    _context.Patients.Add(patient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
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