using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareCheck.DomainClasses
{

    [DataContract(IsReference = true)]
    public class Schedule
    {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime DateTime { get; set; }

        [DataMember]
        public int PatientId { get; set; }

        [DataMember]
        public int EmployeeId { get; set; }

        [DataMember]
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [DataMember]
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [DataMember]
        public ICollection<TodoList> TodoList { get; set; }





    }
}
