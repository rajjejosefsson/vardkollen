using System.Collections.Generic;
using CareCheck.DomainClasses;

namespace CareCheck.MVC.Admin.ViewModels
{
    public class PatientAndScheduleViewModel
    {
        public Relative Relative { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

        public Patient Patient { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}