using System.Collections.Generic;
using CareCheck.DomainClasses;

namespace CareCheck.MVC.Admin.ViewModels
{
    public class PatientsAndRelativesViewModel
    {
        public ICollection<Patient> Patients { get; set; }
        public int PatientId { get; set; }
        public ICollection<Relative> Relatives { get; set; }
        public int RelativeId { get; set; }
    }
}