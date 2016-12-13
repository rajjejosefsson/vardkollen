using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace CareCheck.MVC.Relatives.ViewModels
{
    public class PatientAndScheduleViewModel
    {
        public Relative Relative { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

        public Patient Patient { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}