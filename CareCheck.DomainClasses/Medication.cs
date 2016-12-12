using System.Collections.Generic;
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

        [DataMember]
        public ICollection<Patient> Patients { get; set; }

    }
}
