using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace vardkollen.ViewModels
{
    public class EmployeeSheduleTasksViewModel
    {


        public ICollection<Schedule> Schedules { get; set; }

        public Schedule Schedule { get; set; }
        public Patient Patient { get; set; }



    }
}


/*
 
     
     Id int 
Todolist list 
Date datetime
Patient patient 
     
     
     */
