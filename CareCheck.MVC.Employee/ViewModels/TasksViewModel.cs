using System.Collections.Generic;
using CareCheck.DomainClasses;
using CareCheck.MVC.Employee.Models;

namespace CareCheck.MVC.Employee.ViewModels
{
    public class TasksViewModel
    {
       
         
        public DomainClasses.Employee Employee { get; set; }
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