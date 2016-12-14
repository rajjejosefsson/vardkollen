using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareCheck.DomainClasses
{
    [DataContract(IsReference = true)]
    [Table("TodoList")]
    public class TodoList
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int TaskId { get; set; }

        [DataMember]
        public int ScheduleId { get; set; }

        [DataMember]
        public bool IsDone { get; set; }



        [DataMember]
        [ForeignKey("TaskId")]
        public Task Task { get; set; }

        [DataMember]
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; }


    }
}
