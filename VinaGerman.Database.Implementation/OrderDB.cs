using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;
using Dapper;
using VinaGerman.Entity.BusinessEntity;
namespace VinaGerman.Database.Implementation
{
    public class OrderDB : BaseDB, IOrderDB
    {
        public List<OrderEntity> SearchOrder(OrderSearchEntity searchObject)
        {
            List<OrderEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Order.OrderId," + Environment.NewLine +
                "Order.OrderType," + Environment.NewLine +
                "Order.BusinessId," + Environment.NewLine +
                "Order.IndustryId," + Environment.NewLine +
                "Order.CreatedBy," + Environment.NewLine +
                "Order.ResponsibleBy" + Environment.NewLine +
                "Order.OrderDate," + Environment.NewLine +
                "Order.CreatedDate," + Environment.NewLine +
                "Order.CustomerCompanyId," + Environment.NewLine +
                "Order.CustomerContactId," + Environment.NewLine +
                "Order.OrderNumber," + Environment.NewLine +

                "Co.Description as CompanyName," + Environment.NewLine +
                "CT.Description as ContactName," + Environment.NewLine +

                "Order.Description" + Environment.NewLine +
                "FROM Order Or,Company Co, Contact CT" + Environment.NewLine +
                "WHERE Or.CustomerCompanyId=Co.CompanyId AND Or.CustomerContactId=CT.ContactId " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (OrderNumber LIKE N'%" + searchObject.SearchText + "%' OR Description LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<OrderEntity>(sqlStatement).ToList();
            }
            return result;
        }

        public OrderEntity AddOrUpdateOrder(OrderEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.OrderId > 0)
            {
                sqlStatement += "UPDATE Order SET  " + Environment.NewLine +
                "OrderType=@OrderType," + Environment.NewLine +
                "BusinessId=@BusinessId," + Environment.NewLine +
                "IndustryId=@IndustryId," + Environment.NewLine +
                "CreatedBy=@CreatedBy," + Environment.NewLine +
                "ResponsibleBy=@ResponsibleBy" + Environment.NewLine +
                "OrderDate=@OrderDate," + Environment.NewLine +
                "CreatedDate=@CreatedDate," + Environment.NewLine +
                "CustomerCompanyId=@CustomerCompanyId," + Environment.NewLine +
                "CustomerContactId=@CustomerContactId," + Environment.NewLine +
                "OrderNumber=@OrderNumber," + Environment.NewLine +
                "Description=@Description" + Environment.NewLine +
                "WHERE OrderId=@OrderId " + Environment.NewLine +
                "SELECT @OrderId AS OrderId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Order(  " + Environment.NewLine +
                "Order.OrderType," + Environment.NewLine +
                "Order.BusinessId," + Environment.NewLine +
                "Order.IndustryId," + Environment.NewLine +
                "Order.CreatedBy," + Environment.NewLine +
                "Order.ResponsibleBy" + Environment.NewLine +
                "Order.OrderDate," + Environment.NewLine +
                "Order.CreatedDate," + Environment.NewLine +
                "Order.CustomerCompanyId," + Environment.NewLine +
                "Order.CustomerContactId," + Environment.NewLine +
                "Order.OrderNumber," + Environment.NewLine +
                "Order.Description)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@OrderType," + Environment.NewLine +
                "@BusinessId," + Environment.NewLine +
                "@IndustryId," + Environment.NewLine +
                "@CreatedBy," + Environment.NewLine +
                "@ResponsibleBy" + Environment.NewLine +
                "@OrderDate," + Environment.NewLine +
                "@CreatedDate," + Environment.NewLine +
                "@CustomerCompanyId," + Environment.NewLine +
                "Order.CustomerContactId," + Environment.NewLine +
                "Order.OrderNumber," + Environment.NewLine +
                "Order.Description)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS OrderId" + Environment.NewLine;
            }

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                entityObject.OrderId = conn.ExecuteScalar<int>(sqlStatement, new
                {
                    OrderId = entityObject.OrderId,
                    OrderType = entityObject.OrderType,
                    BusinessId = entityObject.BusinessId,
                    IndustryId = entityObject.IndustryId,
                    CreatedBy = entityObject.CreatedBy,
                    ResponsibleBy = entityObject.ResponsibleBy,

                    OrderDate = entityObject.OrderDate,
                    CreatedDate = entityObject.CreatedDate,
                    CustomerCompanyId = entityObject.CustomerCompanyId,
                    CustomerContactId = entityObject.CustomerContactId,
                    OrderNumber = entityObject.OrderNumber,
                    Description = entityObject.Description
                });
            }
            return entityObject;
        }
        public bool DeleteOrder(OrderEntity entityObject)
        {
            string sqlStatement = "UPDATE Order SET Deleted=1 WHERE OrderId=@OrderId  " + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                conn.Execute(sqlStatement, new { OrderId = entityObject.OrderId });
            }
            return true;
        }
        public List<OrderlineEntity> GetOrderRelationsForOrder(OrderEntity searchObject)
        {
            List<OrderlineEntity> result = null;
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Orderline.OrderlineId," + Environment.NewLine +
                "Orderline.OrderId," + Environment.NewLine +
                "Orderline.Commission," + Environment.NewLine +
                "Orderline.ArticleId," + Environment.NewLine +
                "Orderline.Quantity," + Environment.NewLine +
                "Orderline.Price," + Environment.NewLine +
                "Orderline.CreatedBy," + Environment.NewLine +
                "Orderline.CreatedDate," + Environment.NewLine +
                "Orderline.ModifiedBy," + Environment.NewLine +
                "Orderline.ModifiedDate," + Environment.NewLine +

                "Article.CategoryId," + Environment.NewLine +
                "Article.ArticleNo," + Environment.NewLine +
                "Article.Description," + Environment.NewLine +
                "Article.Unit," + Environment.NewLine +
                "Orderline.Deleted," + Environment.NewLine +

                "FROM Orderline JOIN Article ON Orderline.ArticleId=Article.ArticleId " + Environment.NewLine +
                "WHERE Deleted=0 AND Orderline.OrderId=@OrderId" + Environment.NewLine;
            
            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<OrderlineEntity>(sqlStatement, new { OrderId = searchObject.OrderId }).ToList();
            }
            return result;
        }
        public OrderlineEntity AddOrUpdateOrderRelation(OrderlineEntity entityObject)
        {
            string sqlStatement = "";

            sqlStatement += "DECLARE @NewOrderlineId INT " + Environment.NewLine;
            //if insert
            if (entityObject.OrderlineId > 0)
            {
                sqlStatement += "UPDATE Orderline SET  " + Environment.NewLine +
                //"OrderId=@OrderId" + Environment.NewLine +
                "Commission=@Commission" + Environment.NewLine +
                "ArticleId=@ArticleId" + Environment.NewLine +
                "Quantity=@Quantity" + Environment.NewLine +
                "Price=@Price" + Environment.NewLine +
                "CreatedBy=@CreatedBy" + Environment.NewLine +
                "CreatedDate=@CreatedDate" + Environment.NewLine +
                "ModifiedBy=@ModifiedBy" + Environment.NewLine +
                "ModifiedDate=@ModifiedDate" + Environment.NewLine +
                "WHERE OrderlineId=@OrderlineId " + Environment.NewLine +
                "SET @NewOrderlineId = @OrderlineId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Orderline(  " + Environment.NewLine +
                "OrderId," + Environment.NewLine +
                "Commission," + Environment.NewLine +
                "ArticleId,)" + Environment.NewLine +
                "Quantity," + Environment.NewLine +
                "Price," + Environment.NewLine +
                "CreatedBy,)" + Environment.NewLine +
                "CreatedDate," + Environment.NewLine +
                "ModifiedBy," + Environment.NewLine +
                "ModifiedDate)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +                
                "@OrderId," + Environment.NewLine +
                "@Commission," + Environment.NewLine +
                "@ArticleId," + Environment.NewLine +
                "@Quantity," + Environment.NewLine +
                "@Price," + Environment.NewLine +
                "@CreatedBy," + Environment.NewLine +
                "@CreatedDate," + Environment.NewLine +
                "@ModifiedBy," + Environment.NewLine +
                "@ModifiedDate)" + Environment.NewLine +
                "SET @NewOrderlineId = (SELECT SCOPE_IDENTITY()) " + Environment.NewLine;
            }

            sqlStatement += "SELECT " + Environment.NewLine +
                "Orderline.OrderlineId," + Environment.NewLine +
                "Orderline.OrderId," + Environment.NewLine +
                "Orderline.Commission," + Environment.NewLine +
                "Orderline.ArticleId," + Environment.NewLine +
                "Orderline.Quantity," + Environment.NewLine +
                "Orderline.Price," + Environment.NewLine +
                "Orderline.CreatedBy," + Environment.NewLine +
                "Orderline.CreatedDate," + Environment.NewLine +
                "Orderline.ModifiedBy," + Environment.NewLine +
                "Orderline.ModifiedDate," + Environment.NewLine +
                "Article.CategoryId," + Environment.NewLine +
                "Article.ArticleNo," + Environment.NewLine +
                "Article.Description," + Environment.NewLine +
                "Article.Unit," + Environment.NewLine +
                "Orderline.Deleted," + Environment.NewLine +
                "FROM Orderline JOIN Article ON Orderline.ArticleId=Article.ArticleId " + Environment.NewLine +
                "WHERE Deleted=0 AND Orderline.OrderId=@NewOrderlineId" + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                var result = conn.Query<OrderlineEntity>(sqlStatement, new
                {
                    OrderlineId = entityObject.OrderId,
                    OrderId = entityObject.OrderId,
                    Commission = entityObject.Commission,
                    ArticleId = entityObject.ArticleId,
                    Quantity = entityObject.Quantity,
                    Price = entityObject.Price,
                    CreatedBy = entityObject.CreatedBy,
                    CreatedDate = entityObject.CreatedDate,

                    ModifiedBy = entityObject.ModifiedBy,
                    ModifiedDate = entityObject.ModifiedDate,
                    CategoryId = entityObject.CategoryId,
                    ArticleNo = entityObject.ArticleNo,

                    Description = entityObject.Description,
                    Unit = entityObject.Unit,
                    Deleted = entityObject.Deleted,
                }).ToList();

                if(result.Count > 0)
                    entityObject = result[0];
                else
                    entityObject = null;
            }
            return entityObject;
        }
        public bool DeleteOrderRelation(OrderlineEntity entityObject)
        {
            string sqlStatement = "DELETE FROM Orderline WHERE OrderlineId=@OrderlineId  " + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                conn.Execute(sqlStatement, new { OrderlineId = entityObject.OrderlineId });
            }
            return true;
        }
    }
}
