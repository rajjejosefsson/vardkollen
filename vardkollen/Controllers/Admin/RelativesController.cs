using CareCheck.DataAccess;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vardkollen.ViewModels;

namespace vardkollen.Controllers
{
    public class RelativesController : Controller
    {

        private readonly CareCheckDbContext _context = new CareCheckDbContext();


        public ActionResult Index()
        {
            var relative = _context.Relatives.Where(r => r.PhoneNumber == "0734214122")
                                             .Include(p => p.Patients)
                                             .Single();


            var viewModel = new PatientAndScheduleViewModel
            {
                Relative = relative,
                Patients = relative.Patients,
            };

            return View(viewModel);
        }



        // Partialview with all relative information
        public ActionResult RelativeInformation(int? id)
        {
            var patient = _context.Patients.Where(p => p.Id == id).Include(m => m.Medications).Single();

            var schedule =
                _context.Schedules.Where(p => p.PatientId == patient.Id)
                .Include(d => d.TodoList.Select(t => t.Task))
                .OrderByDescending(s => s.DateTime)
                .ToList();

            var viewModel = new PatientAndScheduleViewModel
            {
                Patient = patient,
                Schedules = schedule
            };

            return PartialView("_RelativePartialView", viewModel);
        }







        // Index
        public ActionResult RelativeConnection()
        {
            var patients = _context.Patients.ToList();
            var relatives = _context.Relatives.ToList();

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
            // Get patient and relative object
            var relative = _context.Relatives.Single(r => r.Id == viewModel.RelativeId);
            var patient = _context.Patients.Single(p => p.Id == viewModel.PatientId);

            // Connects the relative with patient using navigations (collection) in EF 
            patient.Relatives.Add(relative);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}











/*
         var patient = _context.Patients.Where(p => p.Id == id)
                .Include(m => m.Medications)
                .Include(s => s.Schedules.Select(t => t.TodoList.Select(i => i.Task)))
                .Single();     
*/
