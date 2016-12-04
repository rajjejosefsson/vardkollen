using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace vardkollen.ViewModels
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
    }
}