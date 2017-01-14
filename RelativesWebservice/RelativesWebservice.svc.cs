using CareCheck.DataAccess.Repositories;
using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace RelativesWebservice
{
    public class RelativesWebservice : IRelativesWebservice
    {
        private readonly RelativeRepository _relativeRepository = new RelativeRepository();
        private readonly ScheduleRepository _scheduleRepository = new ScheduleRepository();



        public Relative RelativesPatientByEmail(string relativeEmail)
        {
            return _relativeRepository.RelativesPatientByEmail(relativeEmail);
        }



        public ICollection<Schedule> PatientDetailSchedules(int patientId)
        {
            return _scheduleRepository.PatientDetailSchedulesById(patientId);
        }



        public Patient PatientDetailInfoById(int patientId)
        {
            return _relativeRepository.PatientDetailInfoById(patientId);
        }

    }
}
