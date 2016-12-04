using System;

namespace demo
{
    public class StaffSchedule
    {
        public int StaffId { get; set; }
        public int ScheduleId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Patient Schedule { get; set; }

        public DateTime DateTime { get; set; }
    }
}
