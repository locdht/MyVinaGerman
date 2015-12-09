using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Database
{
    public interface IOrderDB
    {
        List<OrderEntity> SearchOrder(OrderSearchEntity searchObject);
        OrderEntity AddOrUpdateOrder(OrderEntity entityObject);
        bool DeleteOrder(OrderEntity entityObject);

        List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject);
        OrderlineEntity AddOrUpdateOrderline(OrderlineEntity entityObject);
        bool DeleteOrderline(OrderlineEntity entityObject);

        List<LoanEntity> GetLoansForOrderline(OrderlineEntity searchObject);
        LoanEntity AddOrUpdateLoan(LoanEntity entityObject);
        bool DeleteLoan(LoanEntity entityObject);
    }
}
