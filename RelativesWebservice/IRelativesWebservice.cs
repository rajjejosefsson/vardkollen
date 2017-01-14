using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.ServiceModel;

namespace RelativesWebservice
{
    [ServiceContract]
    public interface IRelativesWebservice
    {
        [OperationContract]
        Relative RelativesPatientByEmail(string relativeEmail);


        [OperationContract]
        ICollection<Schedule> PatientDetailSchedules(int patientId);


        [OperationContract]
        Patient PatientDetailInfoById(int patientId);
    }
}
