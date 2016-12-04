using System.Collections.Generic;

namespace CareCheck.DomainClasses
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArticleNumber { get; set; }

        public ICollection<Patient> Patients { get; set; }

    }
}
