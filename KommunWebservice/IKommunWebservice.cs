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
        Employee GetEmployee(int id);

        [OperationContract]
        void InsertOrUpdateEmployee(Employee employee);

        [OperationContract]
        void DeletEmployee(int id);





        // Patients

        [OperationContract]
        ICollection<Patient> PatientList();

        [OperationContract]
        Patient GetPatient(int id);

        [OperationContract]
        void InsertOrUpdatePatient(Patient patient);

        [OperationContract]
        void DeletePatient(int id);
        [OperationContract]
        Schedule PatientScheduleById(int id);



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
        Relative GetRelativesPatient(string number);

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
        ICollection<Schedule> ScheduleList();

        [OperationContract]
        Schedule InsertOrUpdateSchedule(Schedule schedule);

        [OperationContract]
        Schedule Schedule(int id);

        [OperationContract]
        void DeleteSchedule(int id);

        [OperationContract]
        ICollection<Schedule> PatientsSchedules();


        [OperationContract]
        void SaveSchedule();




        // Todos
        [OperationContract]
        void InsertTodo(TodoList todoItem);

        [OperationContract]
        ICollection<TodoList> Todos();



    }
}

