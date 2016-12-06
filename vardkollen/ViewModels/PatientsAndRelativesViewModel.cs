using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace vardkollen.ViewModels
{
    public class PatientsAndRelativesViewModel
    {
        public List<Patient> Patients { get; set; }
        public int PatientId { get; set; }
        public List<Relative> Relatives { get; set; }

        public int RelativeId { get; set; }
    }
}