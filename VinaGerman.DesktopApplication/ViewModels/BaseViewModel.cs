using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinaGerman.DesktopApplication.Utilities;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace VinaGerman.DesktopApplication.ViewModels
{
    public class BaseViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        #region properties
        /// <summary>
        /// This ID is used for send/receive message
        /// </summary>
        public string MessengerID { get; set; }                   

        #endregion        

        #region Constructor
        public BaseViewModel()
        {
            //register to receive messages from other ViewModels                 
            AcceptedToken = new ObservableCollection<string>();
            AcceptedToken.CollectionChanged += AcceptedToken_CollectionChanged;
        }

        void AcceptedToken_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    Messenger.Default.Register<BaseMessage>(this, e.NewItems[i], MessageReceiver);
                }
            }
        }

        public virtual void Reset() { }
        #endregion        

        #region Message processing        
        public ObservableCollection<string> AcceptedToken { get; private set; }
        
        private bool CanReceived(BaseMessage pMessage)
        {
            bool bCanReceive = false;
            if (pMessage.Receivers == null || pMessage.Receivers.Count == 0)
            {
                bCanReceive = true;
            }
            else
            {
                for (int i = 0; i < pMessage.Receivers.Count; i++)
                {
                    if (string.Compare(this.MessengerID, pMessage.Receivers[i], true) == 0)
                    {
                        bCanReceive = true;
                        break;
                    }
                }
            }
            return bCanReceive;
        }

        private void MessageReceiver(BaseMessage pMessage)
        {
            if (CanReceived(pMessage))
            {
                MessageHandler(pMessage);
            }
        }

        protected virtual void MessageHandler(BaseMessage pMessage) { }

        protected void SendMessage(string sMessage, Dictionary<string, object> dicParameters, params string[] arrReceivers)
        {
            BaseMessage message = new BaseMessage();
            message.Sender = this.MessengerID;
            message.Token = sMessage;
            message.Parameters = dicParameters;
            if (arrReceivers == null || arrReceivers.Length == 0)
                message.Receivers = null;
            else
                message.Receivers = arrReceivers.ToList();
            Messenger.Default.Send<BaseMessage>(message, message.Token);
        }
        #endregion                

    }
}
