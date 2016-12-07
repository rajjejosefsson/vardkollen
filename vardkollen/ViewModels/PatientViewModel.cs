using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vardkollen.ViewModels
{
    public class PatientViewModel
    {

        public Patient Patient { get; set; }
        public IEnumerable<Patient> Patients { get; set; }



        [Required(ErrorMessage = "Förnamn måste anges")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Efternamn måste anges")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Personnummer måste anges")]
        public string PersonNumber { get; set; }



        [Required(ErrorMessage = "Telefonnummer måste anges")]
        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Adress måste anges")]
        public string Adress { get; set; }



        [Required(ErrorMessage = "Postnummer måste anges")]
        public string ZipCode { get; set; }






    }
}