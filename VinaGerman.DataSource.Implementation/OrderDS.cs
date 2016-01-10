using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Service;

namespace VinaGerman.DataSource.Implementation
{
    public class OrderDS : BaseDS<IOrderSvc>, IOrderDS
    {
        protected override string CategoryName
        {
            get
            {
                return "Order.svc";
            }
        }

        #region Order
        public List<OrderEntity> SearchOrder(OrderSearchEntity searchObject)
        {
            IOrderSvc channel = CreateChannel();
            var result = channel.SearchOrder(searchObject);
            channel.Dispose();
            return result;
        }
        public OrderEntity AddOrUpdateOrder(OrderEntity entityObject)
        {
            IOrderSvc channel = CreateChannel();
            var result = channel.AddOrUpdateOrder(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteOrder(OrderEntity entityObject)
        {
            IOrderSvc channel = CreateChannel();
            var result = channel.DeleteOrder(entityObject);
            channel.Dispose();
            return result;
        }
        public List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject, bool populateLoan)
        {
            IOrderSvc channel = CreateChannel();
            var result = channel.GetOrderlinesForOrder(searchObject, populateLoan);
            channel.Dispose();
            return result;
        }       
        #endregion
    }
}
