using CareCheck.DomainClasses;
using CareCheck.MVC.Relatives.Models;
using System.Collections.Generic;

namespace CareCheck.MVC.Relatives.ViewModels
{
    public class TasksViewModel
    {


        public Employee Employee { get; set; }
        public Patient Patient { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

        public Schedule Schedule { get; set; }



        public List<TasksModel> Tasks { get; set; }
        public List<Medication> Medications { get; set; }


        public TasksViewModel()
        {
            Tasks = new List<TasksModel>();

        }


    }
}


/*
 
     
     Id int 
Todolist list 
Date datetime
Patient patient 
     
     
     */
