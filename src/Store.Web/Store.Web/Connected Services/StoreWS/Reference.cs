﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.Web.StoreWS
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "StoreWS.ServiceSoap")]
    public interface ServiceSoap
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ImportFile", ReplyAction = "*")]
        void ImportFile(string filePath);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ImportFile", ReplyAction = "*")]
        System.Threading.Tasks.Task ImportFileAsync(string filePath);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceSoapChannel : Store.Web.StoreWS.ServiceSoap, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSoapClient : System.ServiceModel.ClientBase<Store.Web.StoreWS.ServiceSoap>, Store.Web.StoreWS.ServiceSoap
    {

        public ServiceSoapClient()
        {
        }

        public ServiceSoapClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public ServiceSoapClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public ServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public ServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public void ImportFile(string filePath)
        {
            base.Channel.ImportFile(filePath);
        }

        public System.Threading.Tasks.Task ImportFileAsync(string filePath)
        {
            return base.Channel.ImportFileAsync(filePath);
        }
    }
}
