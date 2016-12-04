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






            // get the id of the relative (use email and password)
            // Get the first relative we find and stop search,
            // or return default if no found   defaults: (int = 0, Object: null)
            var relative = _context.Relatives.Where(r => r.PhoneNumber == "0734214122").FirstOrDefault();


            // var relativeWithPatient = _context.Relatives.Where(r => r.Id == relative.Id).Include(p => p.Patients).Select(p => p.Patients).FirstOrDefault();


            var patientOfRelative = _context.Relatives
                .Where(r => r.Id == relative.Id)
                .Include(p => p.Patients.Select(m => m.Medications)).FirstOrDefault();


            //    var test =  _context.Schedules.Where(p => p.PatientId == 1).Include(t => t.ToDoList);
            // Returns a list of patients connected schedules
            var schedulesOfPatient = _context.Schedules.Where(p => p.PatientId == 1).Include(list => list.TodoList.Select(t => t.Task)).ToList();





            var viewModel = new PatientAndScheduleViewModel
            {
                Relative = patientOfRelative,
                Schedules = schedulesOfPatient
            };






            return View(viewModel);
        }




        public ActionResult MyAction(int? id)
        {
            // get the id of the relative (use email and password)
            // Get the first relative we find and stop search,
            // or return default if no found   defaults: (int = 0, Object: null)
            var relative = _context.Relatives.Where(r => r.PhoneNumber == "0734214122").FirstOrDefault();




            var patientOfRelative = _context.Relatives
                .Where(r => r.Id == relative.Id)
                .Include(p => p.Patients.Select(m => m.Medications)).FirstOrDefault();



            var viewModel = new PatientAndScheduleViewModel
            {
                Relative = patientOfRelative,
            };


            return PartialView("_RelativePartialView", viewModel);
        }


        public void test()
        {
        }

    }
}