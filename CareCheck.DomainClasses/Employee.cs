
using System.Runtime.Serialization;

namespace CareCheck.DomainClasses
{
    [DataContract(IsReference = true)]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PersonNumber { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Adress { get; set; }

        [DataMember]
        public string ZipCode { get; set; }
    }
}
