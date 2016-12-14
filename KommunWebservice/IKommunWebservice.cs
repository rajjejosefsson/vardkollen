using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.ServiceModel;

namespace KommunWebservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKommunWebservice" in both code and config file together.

    [ServiceContract]
    public interface IKommunWebservice
    {



        // Employees

        [OperationContract]
        ICollection<Employee> EmployeeList();

        [OperationContract]
        Employee EmployeeById(int id);

        [OperationContract]
        void InsertOrUpdateEmployee(Employee employee);

        [OperationContract]
        void DeletEmployee(int id);





        // Patients

        [OperationContract]
        ICollection<Patient> PatientList();

        [OperationContract]
        Patient PatientById(int id);

        [OperationContract]
        void InsertOrUpdatePatient(Patient patient);

        [OperationContract]
        void DeletePatient(int id);





        // Relatives

        [OperationContract]
        ICollection<Relative> RelativeList();

        [OperationContract]
        Relative GetRelative(int id);

        [OperationContract]
        void InsertOrUpdateRelative(Relative relative);

        [OperationContract]
        void DeleteRelative(int id);

        [OperationContract]
        void ConnectRelativeAndPatient(int patientId, int relativeId);





        // Tasks

        [OperationContract]
        ICollection<Task> TaskList();

        [OperationContract]
        Task GetTask(int id);

        [OperationContract]
        void InsertOrUpdateTask(Task task);

        [OperationContract]
        void DeleteTask(int id);





        // Schedule

        [OperationContract]
        Schedule InsertOrUpdateSchedule(Schedule schedule);

        [OperationContract]
        Schedule PatientScheduleById(int scheduleId);

        [OperationContract]
        Schedule Schedule(int id);

        [OperationContract]
        void DeleteSchedule(int id);

        [OperationContract]
        ICollection<Schedule> PatientsSchedules();

        [OperationContract]
        ICollection<Schedule> EmployeeSchedule(int employeeId);





        // Todos

        [OperationContract]
        void InsertTodo(TodoList todoItem);

        [OperationContract]
        ICollection<TodoList> Todos();
    }
}

