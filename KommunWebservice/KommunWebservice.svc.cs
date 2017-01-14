using CareCheck.DataAccess.Repositories;
using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace KommunWebservice
{
    public class KommunWebservice : IKommunWebservice
    {
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly PatientRepository _patientRepository = new PatientRepository();
        private readonly RelativeRepository _relativeRepository = new RelativeRepository();
        private readonly TaskRepository _taskRepository = new TaskRepository();
        private readonly TodoListRepository _todoListRepository = new TodoListRepository();
        private readonly ScheduleRepository _scheduleRepository = new ScheduleRepository();





        // Employee
        public ICollection<Employee> EmployeeList()
        {
            return _employeeRepository.EmployeeList();
        }


        public Employee EmployeeById(int employeeId)
        {
            return _employeeRepository.FindById(employeeId);
        }


        public void InsertOrUpdateEmployee(Employee employee)
        {
            _employeeRepository.InsertOrUpdate(employee);
        }


        public void DeletEmployeeById(int employeeId)
        {
            _employeeRepository.DeleteById(employeeId);
        }





        // Patient
        public ICollection<Patient> PatientList()
        {
            return _patientRepository.PatientList();
        }


        public Patient PatientById(int patientId)
        {
            return _patientRepository.FindById(patientId);
        }


        public void InsertOrUpdatePatient(Patient patient)
        {
            _patientRepository.InsertOrUpdate(patient);
        }


        public void DeletePatientById(int patientId)
        {
            _patientRepository.DeleteById(patientId);
        }





        // Relative
        public ICollection<Relative> RelativeList()
        {
            return _relativeRepository.RelativeList();
        }

        public Relative RelativeById(int relativeId)
        {
            return _relativeRepository.FindById(relativeId);
        }


        public void InsertOrUpdateRelative(Relative relative)
        {
            throw new System.NotImplementedException();
        }


        public void DeleteRelativeById(int relativeId)
        {
            throw new System.NotImplementedException();
        }


        public void ConnectRelativeAndPatient(int patientId, int relativeId)
        {
            _relativeRepository.ConnectRelativeAndPatient(patientId, relativeId);
        }





        // Tasks
        public ICollection<Task> TaskList()
        {
            return _taskRepository.TaskList();
        }


        public Task TaskById(int taskId)
        {
            return _taskRepository.FindById(taskId);
        }


        public void InsertOrUpdateTask(Task task)
        {
            _taskRepository.InsertOrUpdate(task);
        }


        public void DeleteTaskById(int taskId)
        {
            _taskRepository.DeleteById(taskId);
        }





        // Schedule
        public ICollection<Schedule> PatientsSchedules()
        {
            return _scheduleRepository.PatientsSchedules();
        }


        public Schedule PatientScheduleById(int patientId)
        {
            return _scheduleRepository.PatientScheduleById(patientId);
        }



        public ICollection<Schedule> EmployeeSchedulesById(int employeeId)
        {
            return _scheduleRepository.EmployeeSchedulesById(employeeId);
        }


        public Schedule InsertOrUpdateSchedule(Schedule schedule)
        {
            return _scheduleRepository.InsertOrUpdate(schedule);
        }


        public Schedule ScheduleById(int scheduleId)
        {
            return _scheduleRepository.FindById(scheduleId);
        }


        public void DeleteScheduleById(int scheduleId)
        {
            _scheduleRepository.DeleteById(scheduleId);
        }




  
        // Todos
        public ICollection<TodoList> Todos()
        {
            return _todoListRepository.TodoList();
        }


        public void InsertTodo(TodoList todoItem)
        {
            _todoListRepository.InsertTodo(todoItem);
        }

    }
}
