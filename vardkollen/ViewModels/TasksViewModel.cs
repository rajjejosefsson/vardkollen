﻿using CareCheck.DomainClasses;
using System.Collections.Generic;
using vardkollen.Models;

namespace vardkollen.ViewModels
{
    public class TasksViewModel
    {


        public ICollection<Schedule> Schedules { get; set; }

        public Schedule Schedule { get; set; }


        public List<TasksModel> Tasks { get; set; }


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