using CareCheck.DomainClasses;
using System.Collections.Generic;
using vardkollen.Models;

namespace vardkollen.ViewModels
{
    public class ScheduleItemViewModel
    {
        public Patient Patient { get; set; }
        public int ScheduleId { get; set; }





        public List<TasksModel> Tasks { get; set; }

        public ScheduleItemViewModel()
        {
            Tasks = new List<TasksModel>();

        }




    }
}