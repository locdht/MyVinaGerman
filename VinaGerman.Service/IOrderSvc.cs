using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Service
{
    [ServiceContract]
    public interface IOrderSvc : IDisposable
    {
        #region Order
        [OperationContract]
        List<OrderEntity> SearchOrder(OrderSearchEntity searchObject);
        [OperationContract]
        OrderEntity AddOrUpdateOrder(OrderEntity entityObject);
        [OperationContract]
        bool DeleteOrder(OrderEntity entityObject);
        [OperationContract]
        List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject);
        [OperationContract]
        OrderlineEntity AddOrUpdateOrderline(OrderlineEntity entityObject);
        [OperationContract]
        bool DeleteOrderline(OrderlineEntity entityObject);
        [OperationContract]
        List<LoanEntity> GetLoansForOrderline(OrderlineEntity searchObject);
        [OperationContract]
        LoanEntity AddOrUpdateLoan(LoanEntity entityObject);
        [OperationContract]
        bool DeleteLoan(LoanEntity entityObject);
        #endregion
    }
}
