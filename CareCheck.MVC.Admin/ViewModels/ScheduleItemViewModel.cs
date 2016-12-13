using CareCheck.DomainClasses;
using CareCheck.MVC.Admin.Models.CareCheckModels;
using System.Collections.Generic;

namespace CareCheck.MVC.Admin.ViewModels
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