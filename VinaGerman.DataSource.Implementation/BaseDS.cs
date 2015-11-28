using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Wcf.Security;
using VinaGerman.Wcf.Security.Client;

namespace VinaGerman.DataSource.Implementation
{
    public class BaseDS<TChannel>
    {
        #region properties
        public static string HostName = "";
        private string WindowUrl
        {
            get
            {
                HostName = ClientPersonnelHeaderContext.HeaderInformation.ServerUrl;
                return string.Format("{0}/{1}/win", HostName, CategoryName);
            }
        }
        private string UserNameUrl
        {
            get
            {
                HostName = ClientPersonnelHeaderContext.HeaderInformation.ServerUrl;
                return string.Format("{0}/{1}/form", HostName, CategoryName);
            }
        }

        private string CommonUrl
        {
            get
            {
                HostName = ClientPersonnelHeaderContext.HeaderInformation.ServerUrl;
                return string.Format("{0}/{1}/common", HostName, CategoryName);
            }
        }

        private ChannelFactory<TChannel> factoryWindowsAuthChannel;
        private ChannelFactory<TChannel> factoryUserNameAuthChannel;
        private ChannelFactory<TChannel> factoryCommonChannel;
        protected virtual string CategoryName { get; set; }
        #endregion

        #region method      
        protected TChannel CreateCommonChannel()
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.ReceiveTimeout = new TimeSpan(0, 0, 5, 0);
            binding.OpenTimeout = new TimeSpan(0, 0, 1, 0);
            binding.SendTimeout = new TimeSpan(0, 0, 5, 0);
            binding.CloseTimeout = new TimeSpan(0, 0, 1, 0);
            binding.BypassProxyOnLocal = false;

            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.MessageEncoding = WSMessageEncoding.Text;
            binding.TextEncoding = System.Text.Encoding.UTF8;
            binding.UseDefaultWebProxy = false;
            binding.MaxBufferPoolSize = 524288;
            binding.MaxReceivedMessageSize = 2147483647;

            binding.ReaderQuotas.MaxDepth = 32;
            binding.ReaderQuotas.MaxStringContentLength = 2147483647;
            binding.ReaderQuotas.MaxArrayLength = 2147483647;
            binding.ReaderQuotas.MaxBytesPerRead = 8192;
            binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

            factoryCommonChannel = new ChannelFactory<TChannel>(binding, new EndpointAddress(CommonUrl));
            factoryCommonChannel.Endpoint.Behaviors.Add(new PersonnelInspectorBehavior());
            factoryCommonChannel.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;

            var credentialBehaviour = factoryCommonChannel.Endpoint.Behaviors.Find<ClientCredentials>();
            credentialBehaviour.UserName.UserName = ClientPersonnelHeaderContext.HeaderInformation.Username;
            credentialBehaviour.UserName.Password = ClientPersonnelHeaderContext.HeaderInformation.Password;
            return factoryCommonChannel.CreateChannel();


        }


        protected TChannel CreateChannel()
        {
            if (ClientPersonnelHeaderContext.HeaderInformation.IsWindowAuthentication)
            {
                if (factoryWindowsAuthChannel == null || ClientPersonnelHeaderContext.HeaderInformation.IsReset)
                {

                    BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
                    //binding.Security.Mode = SecurityMode.Message;
                    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                    //binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    binding.ReceiveTimeout = new TimeSpan(0, 0, 5, 0);
                    binding.OpenTimeout = new TimeSpan(0, 0, 1, 0);
                    binding.SendTimeout = new TimeSpan(0, 0, 5, 0);
                    binding.CloseTimeout = new TimeSpan(0, 0, 1, 0);
                    binding.BypassProxyOnLocal = false;

                    binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                    binding.MessageEncoding = WSMessageEncoding.Text;
                    binding.TextEncoding = System.Text.Encoding.UTF8;
                    binding.UseDefaultWebProxy = false;
                    binding.MaxBufferPoolSize = 524288;
                    binding.MaxReceivedMessageSize = 2147483647;

                    binding.ReaderQuotas.MaxDepth = 32;
                    binding.ReaderQuotas.MaxStringContentLength = 2147483647;
                    binding.ReaderQuotas.MaxArrayLength = 2147483647;
                    binding.ReaderQuotas.MaxBytesPerRead = 8192;
                    binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

                    factoryWindowsAuthChannel = new ChannelFactory<TChannel>(binding, new EndpointAddress(WindowUrl));
                    factoryWindowsAuthChannel.Endpoint.Behaviors.Add(new PersonnelInspectorBehavior());
                    factoryWindowsAuthChannel.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                    ClientPersonnelHeaderContext.HeaderInformation.IsReset = false;
                }
                return factoryWindowsAuthChannel.CreateChannel();
            }
            else
            {

                if (factoryUserNameAuthChannel == null || (factoryUserNameAuthChannel != null && !ClientPersonnelHeaderContext.HeaderInformation.IsResolved) || ClientPersonnelHeaderContext.HeaderInformation.IsReset)
                {
                    //System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                    BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
                    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    binding.ReceiveTimeout = new TimeSpan(0, 0, 5, 0);
                    binding.OpenTimeout = new TimeSpan(0, 0, 1, 0);
                    binding.SendTimeout = new TimeSpan(0, 0, 5, 0);
                    binding.CloseTimeout = new TimeSpan(0, 0, 1, 0);
                    binding.BypassProxyOnLocal = false;

                    binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                    binding.MessageEncoding = WSMessageEncoding.Text;
                    binding.TextEncoding = System.Text.Encoding.UTF8;
                    binding.UseDefaultWebProxy = false;
                    binding.MaxBufferPoolSize = 524288;
                    binding.MaxReceivedMessageSize = 2147483647;

                    binding.ReaderQuotas.MaxDepth = 32;
                    binding.ReaderQuotas.MaxStringContentLength = 2147483647;
                    binding.ReaderQuotas.MaxArrayLength = 2147483647;
                    binding.ReaderQuotas.MaxBytesPerRead = 8192;
                    binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

                    factoryUserNameAuthChannel = new ChannelFactory<TChannel>(binding, new EndpointAddress(UserNameUrl));
                    factoryUserNameAuthChannel.Endpoint.Behaviors.Add(new PersonnelInspectorBehavior());
                    factoryUserNameAuthChannel.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;
                    ClientPersonnelHeaderContext.HeaderInformation.IsReset = false;
                }

                var credentialBehaviour = factoryUserNameAuthChannel.Endpoint.Behaviors.Find<ClientCredentials>();
                credentialBehaviour.UserName.UserName = ClientPersonnelHeaderContext.HeaderInformation.Username;
                credentialBehaviour.UserName.Password = ClientPersonnelHeaderContext.HeaderInformation.Password;

                return factoryUserNameAuthChannel.CreateChannel();
            }
        }
        #endregion
    }
}
