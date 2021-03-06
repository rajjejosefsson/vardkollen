﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareCheck.MVC.Admin.RelativesWebservice {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RelativesWebservice.IRelativesWebservice")]
    public interface IRelativesWebservice {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRelativesWebservice/RelativesPatientByEmail", ReplyAction="http://tempuri.org/IRelativesWebservice/RelativesPatientByEmailResponse")]
        CareCheck.DomainClasses.Relative RelativesPatientByEmail(string relativeEmail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRelativesWebservice/RelativesPatientByEmail", ReplyAction="http://tempuri.org/IRelativesWebservice/RelativesPatientByEmailResponse")]
        System.Threading.Tasks.Task<CareCheck.DomainClasses.Relative> RelativesPatientByEmailAsync(string relativeEmail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRelativesWebservice/PatientDetailSchedules", ReplyAction="http://tempuri.org/IRelativesWebservice/PatientDetailSchedulesResponse")]
        CareCheck.DomainClasses.Schedule[] PatientDetailSchedules(int patientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRelativesWebservice/PatientDetailSchedules", ReplyAction="http://tempuri.org/IRelativesWebservice/PatientDetailSchedulesResponse")]
        System.Threading.Tasks.Task<CareCheck.DomainClasses.Schedule[]> PatientDetailSchedulesAsync(int patientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRelativesWebservice/PatientDetailInfoById", ReplyAction="http://tempuri.org/IRelativesWebservice/PatientDetailInfoByIdResponse")]
        CareCheck.DomainClasses.Patient PatientDetailInfoById(int patientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRelativesWebservice/PatientDetailInfoById", ReplyAction="http://tempuri.org/IRelativesWebservice/PatientDetailInfoByIdResponse")]
        System.Threading.Tasks.Task<CareCheck.DomainClasses.Patient> PatientDetailInfoByIdAsync(int patientId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRelativesWebserviceChannel : CareCheck.MVC.Admin.RelativesWebservice.IRelativesWebservice, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RelativesWebserviceClient : System.ServiceModel.ClientBase<CareCheck.MVC.Admin.RelativesWebservice.IRelativesWebservice>, CareCheck.MVC.Admin.RelativesWebservice.IRelativesWebservice {
        
        public RelativesWebserviceClient() {
        }
        
        public RelativesWebserviceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RelativesWebserviceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RelativesWebserviceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RelativesWebserviceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CareCheck.DomainClasses.Relative RelativesPatientByEmail(string relativeEmail) {
            return base.Channel.RelativesPatientByEmail(relativeEmail);
        }
        
        public System.Threading.Tasks.Task<CareCheck.DomainClasses.Relative> RelativesPatientByEmailAsync(string relativeEmail) {
            return base.Channel.RelativesPatientByEmailAsync(relativeEmail);
        }
        
        public CareCheck.DomainClasses.Schedule[] PatientDetailSchedules(int patientId) {
            return base.Channel.PatientDetailSchedules(patientId);
        }
        
        public System.Threading.Tasks.Task<CareCheck.DomainClasses.Schedule[]> PatientDetailSchedulesAsync(int patientId) {
            return base.Channel.PatientDetailSchedulesAsync(patientId);
        }
        
        public CareCheck.DomainClasses.Patient PatientDetailInfoById(int patientId) {
            return base.Channel.PatientDetailInfoById(patientId);
        }
        
        public System.Threading.Tasks.Task<CareCheck.DomainClasses.Patient> PatientDetailInfoByIdAsync(int patientId) {
            return base.Channel.PatientDetailInfoByIdAsync(patientId);
        }
    }
}
