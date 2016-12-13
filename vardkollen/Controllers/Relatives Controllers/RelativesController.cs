using System.Web.Mvc;
using vardkollen.KommunWebservice;
using vardkollen.ViewModels;

namespace vardkollen.Controllers
{
    public class RelativesController : Controller
    {


        private readonly KommunWebserviceClient _kommunWcfClient = new KommunWebserviceClient();



        // TODO Move two first Actions to Relative Project (ASP.NET) and use wcf


        public ActionResult Index()
        {
            // Change to get by email instead
            var relative = _kommunWcfClient.RelativesPatientByEmail("0734214122");


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



            var patient = _kommunWcfClient.PatientDetailInfoById(id);

            var schedule = _kommunWcfClient.PatientDetailSchedules(id);



            var viewModel = new PatientAndScheduleViewModel
            {
                Patient = patient,
                Schedules = schedule,
            };

            return PartialView("_RelativePartialView", viewModel);
        }







        // Index FOR ADMIN to put somewhere
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



/*




    // Index FOR ADMIN to put somewhere
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
        var patient = _kommunWcfClient.GetPatient(viewModel.PatientId);
        var relative = _kommunWcfClient.GetRelative(viewModel.RelativeId);

        _kommunWcfClient.ConnectRelativeAndPatient(patient, relative);

        return RedirectToAction("Index");
    }


 */
