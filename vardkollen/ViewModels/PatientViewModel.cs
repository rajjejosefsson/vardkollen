using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vardkollen.ViewModels
{
    public class PatientViewModel
    {

        [Required(AllowEmptyStrings = false)]
        public Patient Patient { get; set; }
        public IEnumerable<Patient> Patients { get; set; }



        [Required(ErrorMessage = "Förnamn Måste anges")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }

        public string ZipCode { get; set; }



        public PatientViewModel()
        {

        }




    }
}