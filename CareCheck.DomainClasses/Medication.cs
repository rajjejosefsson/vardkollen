using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace CareCheck.DomainClasses
{

    [DataContract(IsReference = true)]
    public class Medication
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ArticleNumber { get; set; }


        /* Navigation Properties */


        [DataMember]
        public ICollection<Patient> Patients { get; set; }

        public Medication()
        {
            Patients = new Collection<Patient>();
        }

    }
}
