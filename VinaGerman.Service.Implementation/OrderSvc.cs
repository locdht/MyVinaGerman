using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Business;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Wcf.Security;

namespace VinaGerman.Service.Implementation
{
    [PersonnelInspectorBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OrderSvc : IOrderSvc
    {
        #region Order
        public List<OrderEntity> SearchOrder(OrderSearchEntity searchObject)
        {
            return Factory.Resolve<IOrderBL>().SearchOrder(searchObject);
        }

        public OrderEntity AddOrUpdateOrder(OrderEntity entityObject)
        {
            return Factory.Resolve<IOrderBL>().AddOrUpdateOrder(entityObject);
        }

        public bool DeleteOrder(OrderEntity entityObject)
        {
            return Factory.Resolve<IOrderBL>().DeleteOrder(entityObject);
        }
        public List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject)
        {
            return Factory.Resolve<IOrderBL>().GetOrderlinesForOrder(searchObject);
        }
        public OrderlineEntity AddOrUpdateOrderline(OrderlineEntity entityObject)
        {
            return Factory.Resolve<IOrderBL>().AddOrUpdateOrderline(entityObject);
        }
        public bool DeleteOrderline(OrderlineEntity entityObject)
        {
            return Factory.Resolve<IOrderBL>().DeleteOrderline(entityObject);
        }

        public List<LoanEntity> GetLoansForOrderline(OrderlineEntity searchObject)
        {
            return Factory.Resolve<IOrderBL>().GetLoansForOrderline(searchObject);
        }
        public LoanEntity AddOrUpdateLoan(LoanEntity entityObject)
        {
            return Factory.Resolve<IOrderBL>().AddOrUpdateLoan(entityObject);
        }
        public bool DeleteLoan(LoanEntity entityObject)
        {
            return Factory.Resolve<IOrderBL>().DeleteLoan(entityObject);
        }
        #endregion

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
