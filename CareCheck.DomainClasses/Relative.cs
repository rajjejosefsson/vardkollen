using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace CareCheck.DomainClasses
{
    [DataContract(IsReference = true)]
    public class Relative
    {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Adress { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public ICollection<Patient> Patients { get; set; }


        public Relative()
        {
            Patients = new Collection<Patient>();
        }

    }
}
