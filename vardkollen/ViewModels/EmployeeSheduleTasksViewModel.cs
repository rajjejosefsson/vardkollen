using CareCheck.DomainClasses;
using System;
using System.Collections.Generic;

namespace vardkollen.ViewModels
{
    public class EmployeeSheduleTasksViewModel
    {

        public int ScheduleId { get; set; }

        public List<TodoList> TodoList { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get; set; }



    }
}


/*
 
     
     Id int 
Todolist list 
Date datetime
Patient patient 
     
     
     */
