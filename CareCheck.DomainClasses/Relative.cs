using System.Collections.Generic;

namespace CareCheck.DomainClasses
{
    public class Relative
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Patient> Patients { get; set; }

    }
}
