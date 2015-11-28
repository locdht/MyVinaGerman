using VinaGerman.Wcf.Security.Client;
using VinaGerman.Wcf.Security.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace VinaGerman.Wcf.Security
{
    public class PersonnelInspectorBehavior : Attribute, IDispatchMessageInspector, IClientMessageInspector, IEndpointBehavior, IServiceBehavior
    {        

        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //LocDHT: Retrieve Inbound Object from Request, populate AuthenticationType,UserName,Password
            var header = request.Headers.GetHeader<PersonnelHeader>("personnel-header", "s");            
            if (header != null)
            {
                var token = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity;
                if (token.AuthenticationType == "Windows" ||
                    token.AuthenticationType == "Negotiate" ||
                    token.AuthenticationType == "NTLM") // windows authentication
                {
                    header.IsWindowAuthentication = true;
                    header.Username = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                }
                else // UserName authentication
                {
                    header.IsWindowAuthentication = false;
                    header.Username = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                    if (ServiceSecurityContext.Current.PrimaryIdentity is PersonnelIdentity)
                    {
                        header.Password = ((PersonnelIdentity)ServiceSecurityContext.Current.PrimaryIdentity).Password;
                    }
                }
                
                //CustomHeaderServerContextExtension.Current.CustomHeader = header;
                OperationContext.Current.IncomingMessageProperties.Add("PersonnelHeader", header);
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //No need to do anything else

        }

        #endregion

        #region IClientMessageInspector

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //Instantiate new HeaderObject with values from ClientContext;
            var dataToSend = new PersonnelHeader
            {
                Database = ClientPersonnelHeaderContext.HeaderInformation.Database,
                LanguageId = ClientPersonnelHeaderContext.HeaderInformation.LanguageId
            };
            
            var typedHeader = new MessageHeader<PersonnelHeader>(dataToSend);
            var untypedHeader = typedHeader.GetUntypedHeader("personnel-header", "s");

            request.Headers.Add(untypedHeader);
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            //No need to do anything else
        }

        #endregion

        #region IEndpointBehavior

        public void Validate(ServiceEndpoint endpoint)
        {

        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            var channelDispatcher = endpointDispatcher.ChannelDispatcher;
            if (channelDispatcher == null) return;
            foreach (var ed in channelDispatcher.Endpoints)
            {
                var inspector = new PersonnelInspectorBehavior();
                ed.DispatchRuntime.MessageInspectors.Add(inspector);
            }
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            var inspector = new PersonnelInspectorBehavior() {};
            clientRuntime.MessageInspectors.Add(inspector);
        }

        #endregion

        #region IServiceBehaviour

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (var eDispatcher in cDispatcher.Endpoints)
                {
                    eDispatcher.DispatchRuntime.MessageInspectors.Add(new PersonnelInspectorBehavior());
                }
            }
        }

        #endregion

    }
}
