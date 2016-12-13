using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.ServiceModel;

namespace RelativesWebservice
{
    [ServiceContract]
    public interface IRelativesWebservice
    {
        [OperationContract]
        Relative RelativesPatientByEmail(string email);

        [OperationContract]
        ICollection<Schedule> PatientDetailSchedules(int id);

        [OperationContract]
        Patient PatientDetailInfoById(int id);


    }
}
