﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarOBDMvc.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://WebXml.com.cn/", ConfigurationName="ServiceReference1.IpAddressSearchWebServiceSoap")]
    public interface IpAddressSearchWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getCountryCityByIp", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getCountryCityByIp(string theIpAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getGeoIPContext", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getGeoIPContext();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getVersionTime", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string getVersionTime();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IpAddressSearchWebServiceSoapChannel : CarOBDMvc.ServiceReference1.IpAddressSearchWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IpAddressSearchWebServiceSoapClient : System.ServiceModel.ClientBase<CarOBDMvc.ServiceReference1.IpAddressSearchWebServiceSoap>, CarOBDMvc.ServiceReference1.IpAddressSearchWebServiceSoap {
        
        public IpAddressSearchWebServiceSoapClient() {
        }
        
        public IpAddressSearchWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IpAddressSearchWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IpAddressSearchWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IpAddressSearchWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] getCountryCityByIp(string theIpAddress) {
            return base.Channel.getCountryCityByIp(theIpAddress);
        }
        
        public string[] getGeoIPContext() {
            return base.Channel.getGeoIPContext();
        }
        
        public string getVersionTime() {
            return base.Channel.getVersionTime();
        }
    }
}
