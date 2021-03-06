﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.DataSource
{

    public interface IOrderDS
    {        
        #region Order
        List<OrderEntity> SearchOrder(OrderSearchEntity searchObject);
        OrderEntity AddOrUpdateOrder(OrderEntity entityObject);
        bool DeleteOrder(OrderEntity entityObject);
        List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject, bool populateLoan);
        OrderEntity SaveOrder(OrderEntity order, List<OrderlineEntity> orderlines);
        #endregion
    
    }
}
