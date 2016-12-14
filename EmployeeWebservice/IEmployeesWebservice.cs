using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmployeeWebservice
{
    [ServiceContract]
    public interface IEmployeesWebservice
    {
        [OperationContract]
        Employee EmployeeById(int id);


        [OperationContract]
        ICollection<Schedule> EmployeeSchedule(int employeeId);


        [OperationContract]
        void UpdateTodoList(int scheduleId, bool[] checkBoxes);


        [OperationContract]
        Schedule PatientScheduleById(int id);
    }
}
