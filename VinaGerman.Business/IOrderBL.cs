using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business
{
    public interface IOrderBL
    {
        List<OrderEntity> SearchOrder(OrderSearchEntity searchObject);
        OrderEntity AddOrUpdateOrder(OrderEntity entityObject);
        bool DeleteOrder(OrderEntity entityObject);
        List<OrderlineEntity> GetOrderRelationsForOrder(OrderEntity searchObject);
        OrderlineEntity AddOrUpdateOrderRelation(OrderlineEntity entityObject);
        bool DeleteOrderRelation(OrderlineEntity entityObject);
    }
}
