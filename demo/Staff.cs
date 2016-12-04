using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo
{
    [Table("Staff")]
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }

        public ICollection<StaffSchedule> StaffSchedules { get; set; }
    }
}
