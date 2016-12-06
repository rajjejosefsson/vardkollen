using CareCheck.DomainClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using vardkollen.Models;

namespace vardkollen.ViewModels
{
    public class CreateScheduleViewModel
    {

        [Required, Display(Name = "Datum")]
        public DateTime DateTime { get; set; }



        [Required, Display(Name = "Patienter")]
        public ICollection<Patient> Patients { get; set; }
        public int PatientId { get; set; }



        [Required, Display(Name = "Anställda")]
        public ICollection<Employee> Employees { get; set; }
        public int EmployeeId { get; set; }


        public List<TasksModel> Tasks { get; set; }


        public CreateScheduleViewModel()
        {
            Tasks = new List<TasksModel>();

        }

















    }
}