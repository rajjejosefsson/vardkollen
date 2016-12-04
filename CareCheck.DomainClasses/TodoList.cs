using System.ComponentModel.DataAnnotations.Schema;

namespace CareCheck.DomainClasses
{
    [Table("TodoList")]
    public class TodoList
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public int ScheduleId { get; set; }



        public bool IsDone { get; set; }




        [ForeignKey("TaskId")]
        public Task Task { get; set; }


        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; }


    }
}
