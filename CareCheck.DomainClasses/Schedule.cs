using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareCheck.DomainClasses
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }



        public int PatientId { get; set; }
        public int EmployeeId { get; set; }



        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }


        public ICollection<TodoList> TodoList { get; set; }





    }
}
