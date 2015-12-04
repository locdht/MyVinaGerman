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
        public List<OrderlineEntity> GetOrderRelationsForOrder(OrderEntity searchObject)
        {
            return Factory.Resolve<IOrderDB>().GetOrderRelationsForOrder(searchObject);
        }
        public OrderlineEntity AddOrUpdateOrderRelation(OrderlineEntity entityObject)
        {
            return Factory.Resolve<IOrderDB>().AddOrUpdateOrderRelation(entityObject);
        }
        public bool DeleteOrderRelation(OrderlineEntity entityObject)
        {
            return Factory.Resolve<IOrderDB>().DeleteOrderRelation(entityObject);
        }
    }
}
