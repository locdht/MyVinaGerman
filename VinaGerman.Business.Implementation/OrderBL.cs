using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business.Implementation
{
    public class OrderBL : BaseBL, IOrderBL
    {
        public List<OrderEntity> SearchOrder(OrderSearchEntity searchObject)
        {
            return Factory.Resolve<IOrderDB>().SearchOrder(searchObject);
        }
        public OrderEntity AddOrUpdateOrder(OrderEntity entityObject)
        {
            return Factory.Resolve<IOrderDB>().AddOrUpdateOrder(entityObject);
        }
        public bool DeleteOrder(OrderEntity entityObject)
        {
            return Factory.Resolve<IOrderDB>().DeleteOrder(entityObject);
        }
        public List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject)
        {
            return Factory.Resolve<IOrderDB>().GetOrderlinesForOrder(searchObject);
        }
        public OrderlineEntity AddOrUpdateOrderline(OrderlineEntity entityObject)
        {
            return Factory.Resolve<IOrderDB>().AddOrUpdateOrderline(entityObject);
        }
        public bool DeleteOrderline(OrderlineEntity entityObject)
        {
            return Factory.Resolve<IOrderDB>().DeleteOrderline(entityObject);
        }

        public List<LoanEntity> GetLoansForOrderline(OrderlineEntity searchObject)
        {
            return Factory.Resolve<IOrderDB>().GetLoansForOrderline(searchObject);
        }
        public LoanEntity AddOrUpdateLoan(LoanEntity entityObject)
        {
            return Factory.Resolve<IOrderDB>().AddOrUpdateLoan(entityObject);
        }
        public bool DeleteLoan(LoanEntity entityObject)
        {
            return Factory.Resolve<IOrderDB>().DeleteLoan(entityObject);
        }
    }
}
