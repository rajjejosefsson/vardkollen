using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CareCheck.DomainClasses
{

    [DataContract(IsReference = true)]
    public class Patient
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }

        [DataMember]
        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [DataMember]
        public string PersonNumber { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        [MinLength(2), MaxLength(30)]
        public string Adress { get; set; }

        [DataMember]
        [MinLength(2), MaxLength(15)]
        public string ZipCode { get; set; }



        /* Navigation Properties*/


        [DataMember]
        public ICollection<Relative> Relatives { get; set; }

        [DataMember]
        public ICollection<Schedule> Schedules { get; set; }

        [DataMember]
        public ICollection<Medication> Medications { get; set; }

        public Patient()
        {
            Relatives = new Collection<Relative>();
            Schedules = new Collection<Schedule>();
            Medications = new Collection<Medication>();
        }

    }
}
