using CareCheck.DataAccess;
using CareCheck.DomainClasses;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace vardkollen.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task

        private readonly CareCheckDbContext _context = new CareCheckDbContext();

        public ActionResult Index()
        {


            // Select Day
            // Select Patient
            // Get tasks from that DateTime of the patient
            // Show TaskList of the patient



            var employeeSchedules = _context.Schedules.Where(s => s.EmployeeId == 1).Include(p => p.Patient).Include(t => t.TodoList.Select(task => task.Task)).ToList();

            ViewBag.selected = 0;





            var schedule = new Schedule
            {
                Id = employeeSchedules.ElementAt(0).Id,
                DateTime = employeeSchedules.ElementAt(0).DateTime,
                Patient = employeeSchedules.ElementAt(0).Patient,
                TodoList = employeeSchedules.ElementAt(0).TodoList
            };


            var schedule1 = new Schedule
            {
                Id = employeeSchedules.ElementAt(1).Id,
                DateTime = employeeSchedules.ElementAt(1).DateTime,
                Patient = employeeSchedules.ElementAt(1).Patient,
                TodoList = employeeSchedules.ElementAt(1).TodoList
            };


            var schedule2 = new Schedule
            {
                Id = employeeSchedules.ElementAt(2).Id,
                DateTime = employeeSchedules.ElementAt(2).DateTime,
                Patient = employeeSchedules.ElementAt(2).Patient,
                TodoList = employeeSchedules.ElementAt(2).TodoList
            };




            object[] schedules = { schedule, schedule1, schedule2 };




            var _jsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                //  PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                PreserveReferencesHandling = PreserveReferencesHandling.None

            };

            _jsonSettings.ObjectCreationHandling = ObjectCreationHandling.Auto;
            _jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var serializedStr = JsonConvert.SerializeObject(schedules, Formatting.Indented, _jsonSettings);




            ViewBag.jsonTest = serializedStr;








            return View(employeeSchedules);
        }




        [HttpPost]
        public JsonResult getJsonEmployeeSchedule(string userGuid)
        {




            var employeeSchedules = _context.Schedules.Where(s => s.EmployeeId == 1).Include(p => p.Patient).Include(t => t.TodoList.Select(task => task.Task)).ToList();
            return Json(employeeSchedules, JsonRequestBehavior.AllowGet);
        }

    }
}