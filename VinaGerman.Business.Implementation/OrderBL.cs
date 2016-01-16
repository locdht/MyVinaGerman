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
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IOrderDB>().SearchOrder(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public OrderEntity AddOrUpdateOrder(OrderEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IOrderDB>().AddOrUpdateOrder(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }  
        }
        public bool DeleteOrder(OrderEntity entityObject)
        {
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IOrderDB>().DeleteOrder(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }            
        }
        public List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject, bool populateLoan)
        {
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    var orderlines = db.Resolve<IOrderDB>().GetOrderlinesForOrder(searchObject);
                    if (populateLoan)
                    {
                        for (int i = 0; orderlines != null && i < orderlines.Count; i++)
                        {
                            orderlines[i].LoanList = db.Resolve<IOrderDB>().GetLoansForOrderline(orderlines[i]);
                        }
                    }
                    return orderlines;
                }
                finally
                {
                    db.CloseConnection();
                }
            }                
        }
        public OrderEntity SaveOrder(OrderEntity order, List<OrderlineEntity> orderlines)
        {            
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    db.BeginTransaction();

                    //save order first
                    order = db.Resolve<IOrderDB>().AddOrUpdateOrder(order);

                    //save orderlines
                    if (order != null && order.OrderId > 0)
                    {
                        //save orderlines
                        for (int i = 0; orderlines != null && i < orderlines.Count; i++)
                        {
                            orderlines[i].OrderId = order.OrderId;
                            var newOrderline = db.Resolve<IOrderDB>().AddOrUpdateOrderline(orderlines[i]);
                            if (newOrderline != null && newOrderline.OrderlineId > 0)
                            {
                                orderlines[i].OrderlineId = newOrderline.OrderlineId;
                                //save loan
                                for (int j = 0; j < orderlines[i].LoanList.Count; j++)
                                {
                                    orderlines[i].LoanList[j].OrderlineId = orderlines[i].OrderlineId;
                                    var newLoan = db.Resolve<IOrderDB>().AddOrUpdateLoan(orderlines[i].LoanList[j]);
                                    if (newLoan != null && newLoan.LoanId > 0)
                                    {
                                        orderlines[i].LoanList[j].LoanId = newLoan.LoanId;
                                    }
                                }
                            }
                        }
                    }

                    db.CommitTransaction();
                    return order;
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    throw ex;
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }
    }
}
