using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CareCheck.MVC.Admin.ViewModels
{
    public class CreateEmployeeViewModel
    {

        public Employee Employee { get; set; }
        public IEnumerable<Employee> Employees { get; set; }



        public int Id { get; set; }


        [Required(ErrorMessage = "Förnamn måste anges")]
        [StringLength(60, ErrorMessage = "Får ej vara över sextio bokstäver")]

        public string FirstName { get; set; }


        [Required(ErrorMessage = "Efternamn måste anges")]
        [StringLength(60, ErrorMessage = "Får ej vara över sextio bokstäver")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Personnummer måste anges")]
        [RegularExpression(RegexValidation.SwedishPersonNumber, ErrorMessage = "Personummer ej gilltigt")]
        public string PersonNumber { get; set; }


        [Required(ErrorMessage = "Telefonnummer måste anges")]
        [RegularExpression(RegexValidation.SwedishMobilePhone, ErrorMessage = "Fel format")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Adress måste anges")]
        [StringLength(60, ErrorMessage = "Får ej vara över sextio bokstäver")]
        public string Adress { get; set; }




        [Required(ErrorMessage = "Postnummer måste anges")]
        [RegularExpression(RegexValidation.SwedishPostalCode, ErrorMessage = "Fel format")]
        public string ZipCode { get; set; }
    }
}