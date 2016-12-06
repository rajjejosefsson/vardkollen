using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace vardkollen.ViewModels
{
    public class DeleteScheduleViewModel
    {
        public ICollection<Schedule> Schedules { get; set; }

        public Schedule Schedule { get; set; }
        public Patient Patient { get; set; }
        public int ScheduleId { get; set; }



    }
}