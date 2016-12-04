using System.Collections.Generic;

namespace demo
{
    public class Patient
    {
        public int Id { get; set; }
        public ICollection<StaffSchedule> StaffSchedules { get; set; }
    }
}
