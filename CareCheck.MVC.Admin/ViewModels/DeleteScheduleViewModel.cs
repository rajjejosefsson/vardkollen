using System.Collections.Generic;
using CareCheck.DomainClasses;

namespace CareCheck.MVC.Admin.ViewModels
{
    public class DeleteScheduleViewModel
    {
        public ICollection<Schedule> Schedules { get; set; }

        public Schedule Schedule { get; set; }
        public Patient Patient { get; set; }
        public int ScheduleId { get; set; }



    }
}