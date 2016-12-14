using CareCheck.DataAccess.Repositories;
using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace RelativesWebservice
{
    public class RelativesWebservice : IRelativesWebservice
    {
        private readonly RelativeRepository _relativeRepository = new RelativeRepository();
        private readonly ScheduleRepository _scheduleRepository = new ScheduleRepository();


        public Relative RelativesPatientByEmail(string email)
        {
            return _relativeRepository.RelativesPatientByEmail(email);
        }


        public ICollection<Schedule> PatientDetailSchedules(int id)
        {
            return _scheduleRepository.PatientDetailSchedules(id);
        }


        public Patient PatientDetailInfoById(int id)
        {
            return _relativeRepository.PatientDetailInfoById(id);
        }

    }
}
