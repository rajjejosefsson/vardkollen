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
        Employee EmployeeById(int employeeId);

        [OperationContract]
        void InsertOrUpdateEmployee(Employee employee);

        [OperationContract]
        void DeletEmployeeById(int employeeId);




        // Patients

        [OperationContract]
        ICollection<Patient> PatientList();

        [OperationContract]
        Patient PatientById(int patientId);

        [OperationContract]
        void InsertOrUpdatePatient(Patient patient);

        [OperationContract]
        void DeletePatientById(int patientId);




        // Relatives

        [OperationContract]
        ICollection<Relative> RelativeList();

        [OperationContract]
        Relative RelativeById(int relativeId);

        [OperationContract]
        void InsertOrUpdateRelative(Relative relative);

        [OperationContract]
        void DeleteRelativeById(int relativeId);

        [OperationContract]
        void ConnectRelativeAndPatient(int patientId, int relativeId);




        // Tasks

        [OperationContract]
        ICollection<Task> TaskList();

        [OperationContract]
        Task TaskById(int taskId);

        [OperationContract]
        void InsertOrUpdateTask(Task task);

        [OperationContract]
        void DeleteTaskById(int taskId);




        // Schedule

        [OperationContract]
        Schedule InsertOrUpdateSchedule(Schedule schedule);

        [OperationContract]
        Schedule PatientScheduleById(int scheduleId);

        [OperationContract]
        Schedule ScheduleById(int sheduleId);

        [OperationContract]
        void DeleteScheduleById(int sheduleId);

        [OperationContract]
        ICollection<Schedule> PatientsSchedules();

        [OperationContract]
        ICollection<Schedule> EmployeeSchedulesById(int employeeId);




        // Todos

        [OperationContract]
        void InsertTodo(TodoList todoItem);

        [OperationContract]
        ICollection<TodoList> Todos();
    }
}

