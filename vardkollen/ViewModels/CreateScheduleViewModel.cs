using CareCheck.DomainClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using vardkollen.Models;

namespace vardkollen.ViewModels
{
    public class CreateScheduleViewModel
    {

        [DisplayName("Datum")]
        [Required(ErrorMessage = "Datum måste anges")]
        public DateTime DateTime { get; set; }

        public int PatientId { get; set; }

        public int EmployeeId { get; set; }



        [DisplayName("Patienter")]
        public ICollection<Patient> Patients { get; set; }


        [DisplayName("Anställda")]
        public ICollection<Employee> Employees { get; set; }
        public List<TasksModel> Tasks { get; set; }

        public Task Task { get; set; }


        public CreateScheduleViewModel()
        {
            Tasks = new List<TasksModel>();
            Employees = new List<Employee>();
            Patients = new List<Patient>();

        }

















    }
}