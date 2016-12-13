using CareCheck.DataAccess.Repositories;
using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace EmployeeWebservice
{
    public class EmployeesWebservice : IEmployeesWebservice
    {


        private readonly ScheduleRepository _scheduleRepository = new ScheduleRepository();
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly TodoListRepository _todoListRepository = new TodoListRepository();


        public Employee EmployeeById(int id)
        {
            return _employeeRepository.FindById(id);
        }



        public Schedule PatientScheduleById(int id)
        {
            return _scheduleRepository.PatientScheduleById(id);
        }



        public ICollection<Schedule> EmployeeSchedule(int employeeId)
        {
            return _scheduleRepository.EmployeeSchedules(employeeId);
        }



        public void UpdateTodoList(int scheduleId, bool[] checkBoxes)
        {
            _todoListRepository.UpdateTodoList(scheduleId, checkBoxes);
        }



    }
}
