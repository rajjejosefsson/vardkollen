using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CareCheck.DomainClasses
{
    public class Patient
    {
        public int Id { get; set; }


        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }


        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        public string PersonNumber { get; set; }

        public string PhoneNumber { get; set; }

        [MinLength(2), MaxLength(30)]
        public string Adress { get; set; }

        [MinLength(2), MaxLength(15)]
        public string ZipCode { get; set; }



        public ICollection<Relative> Relatives { get; set; }


        public Patient()
        {
            Relatives = new Collection<Relative>();
        }



        public ICollection<Schedule> Schedules { get; set; }

        public ICollection<Medication> Medications { get; set; }






    }
}
