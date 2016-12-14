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


        public Employee EmployeeById(int id)
        {
            return _employeeRepository.FindById(id);
        }


        public void InsertOrUpdateEmployee(Employee employee)
        {
            _employeeRepository.InsertOrUpdate(employee);
        }


        public void DeletEmployee(int id)
        {
            _employeeRepository.DeleteById(id);
        }




        // Patient
        public ICollection<Patient> PatientList()
        {
            return _patientRepository.PatientList();
        }


        public Patient PatientById(int id)
        {
            return _patientRepository.FindById(id);
        }


        public void InsertOrUpdatePatient(Patient patient)
        {
            _patientRepository.InsertOrUpdate(patient);
        }


        public void DeletePatient(int id)
        {
            _patientRepository.DeleteById(id);
        }




        // Relative
        public ICollection<Relative> RelativeList()
        {
            return _relativeRepository.RelativeList();
        }


        public Relative GetRelative(int id)
        {
            return _relativeRepository.FindById(id);
        }


        public void InsertOrUpdateRelative(Relative relative)
        {
            throw new System.NotImplementedException();
        }


        public void DeleteRelative(int id)
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


        public Task GetTask(int id)
        {
            return _taskRepository.FindById(id);
        }


        public void InsertOrUpdateTask(Task task)
        {
            _taskRepository.InsertOrUpdate(task);
        }


        public void DeleteTask(int id)
        {
            _taskRepository.DeleteById(id);
        }




        // Schedule
        public ICollection<Schedule> PatientsSchedules()
        {
            return _scheduleRepository.PatientsSchedules();
        }


        public Schedule PatientScheduleById(int id)
        {
            return _scheduleRepository.PatientScheduleById(id);
        }


        public ICollection<Schedule> EmployeeSchedule(int employeeId)
        {
            return _scheduleRepository.EmployeeSchedules(employeeId);
        }


        public Schedule InsertOrUpdateSchedule(Schedule schedule)
        {
            return _scheduleRepository.InsertOrUpdate(schedule);
        }


        public Schedule Schedule(int id)
        {
            return _scheduleRepository.FindById(id);
        }


        public void DeleteSchedule(int id)
        {
            _scheduleRepository.DeleteById(id);
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
