﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VinaGerman.DataSource;
using VinaGerman.DesktopApplication.Translations;
using VinaGerman.DesktopApplication.Utilities;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvSaleOrderManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties

        private List<OrderEntity> _orderList = null;
        public List<OrderEntity> OrderList
        {
            get
            {
                return _orderList;
            }
            set
            {
                _orderList = value;
                RaisePropertyChanged("OrderList");
            }
        }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        public RelayCommand<OrderEntity> OpenOrderCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        #endregion


        public uvSaleOrderManagementViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            SearchCommand = new RelayCommand(Search);
            OpenOrderCommand = new RelayCommand<OrderEntity>(OpenOrder);
            ClearSearch();
        }
        #region method      
        public void OpenOrder(OrderEntity entityObject)
        {
            if (entityObject != null && entityObject.OrderId > 0)
            {
                Dictionary<string, object> dicParams = new Dictionary<string, object>();
                dicParams.Add("Order", entityObject);
                SendMessage(MessageToken.ReloadMessage, dicParams, enumView.SaleOrderDetail.ToString());
                GoToView(enumView.SaleOrderDetail);
            }
        }
        public void Search()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var list = Factory.Resolve<IBaseDataDS>().SearchOrder(new OrderSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        OrderList = list.Where(c=>c.OrderType==(int)enumOrderType.Sale).ToList();
                    }));                  
                }
                catch (Exception ex)
                {
                    HideLoading();
                    ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                }
            });            
            //ShowDialog<uvCompanyDetailViewModel>(new uvCompanyDetailViewModel() { 
            //    OriginalCompany = SelectCompany
            //});
        }
        public void ClearSearch()
        {
            SearchText = "";
        }
        #endregion

        #region Message processing
        public override void Reset()
        {
            //reset left panel
            SearchText = "";
            //reload view
            Search();
        }
        protected override void MessageHandler(BaseMessage pMessage)
        {
            if (pMessage.Token == MessageToken.ReloadMessage)
            {
                Reset();
            }
        }
        #endregion
    }
}