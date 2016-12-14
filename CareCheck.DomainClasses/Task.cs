using System.Runtime.Serialization;

namespace CareCheck.DomainClasses
{
    [DataContract(IsReference = true)]
    public class Task
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
