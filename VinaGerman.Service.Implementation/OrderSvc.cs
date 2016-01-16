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
        public List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity order, bool populateLoan)
        {
            return Factory.Resolve<IOrderBL>().GetOrderlinesForOrder(order, populateLoan);
        }
        public OrderEntity SaveOrder(OrderEntity order, List<OrderlineEntity> orderlines)
        {
            return Factory.Resolve<IOrderBL>().SaveOrder(order, orderlines);
        }
        #endregion

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
