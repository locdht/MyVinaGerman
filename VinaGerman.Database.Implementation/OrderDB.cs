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
                "[Order].OrderId," + Environment.NewLine +
                "[Order].OrderType," + Environment.NewLine +
                "[Order].BusinessId," + Environment.NewLine +
                "[Order].IndustryId," + Environment.NewLine +
                "[Order].CreatedBy," + Environment.NewLine +
                "[Order].ResponsibleBy," + Environment.NewLine +
                "[Order].OrderDate," + Environment.NewLine +
                "[Order].CreatedDate," + Environment.NewLine +
                "[Order].CompanyId," + Environment.NewLine +
                "[Order].LocationId," + Environment.NewLine +
                "[Order].CustomerCompanyId," + Environment.NewLine +
                "[Order].CustomerContactId," + Environment.NewLine +
                "[Order].OrderNumber," + Environment.NewLine +
                "[Order].Description," + Environment.NewLine +
                "[Order].OrderStatus," + Environment.NewLine +
                "Company.Description as CustomerCompanyName," + Environment.NewLine +
                "Location.Description as LocationName," + Environment.NewLine +
                "Business.Description as BusinessName," + Environment.NewLine +
                "Industry.Description as IndustryName," + Environment.NewLine +
                "Contact.FullName as CustomerContactName," + Environment.NewLine +
                "ResponsibleContact.FullName as ResponsibleContactName" + Environment.NewLine +
                "FROM [Order] join Company on [Order].CustomerCompanyId = Company.CompanyId join Contact on [Order].CustomerContactId = Contact.ContactId" + Environment.NewLine +
                "join Contact ResponsibleContact on [Order].ResponsibleBy = ResponsibleContact.ContactId" + Environment.NewLine +
                "join Business on [Order].BusinessId = Business.BusinessId" + Environment.NewLine +
                "join Industry on [Order].IndustryId = Industry.IndustryId" + Environment.NewLine +
                "join Location on [Order].LocationId = Location.LocationId" + Environment.NewLine +
                "WHERE 1=1 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND ([Order].OrderNumber LIKE N'%" + searchObject.SearchText + "%' OR [Order].Description LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            if (searchObject.BusinessId > 0)
            {
                sqlStatement += "AND [Order].BusinessId=" + searchObject.BusinessId + Environment.NewLine;
            }
            if (searchObject.IndustryId > 0)
            {
                sqlStatement += "AND [Order].IndustryId=" + searchObject.IndustryId + Environment.NewLine;
            }
            if (searchObject.OrderType > 0)
            {
                sqlStatement += "AND [Order].OrderType=" + searchObject.OrderType + Environment.NewLine;
            }
            //if (searchObject.FromOrderDate != null)
            //{
            //    sqlStatement += "AND Order.OrderDate>=" + searchObject.FromOrderDate + Environment.NewLine;
            //}
            //if (searchObject.ToOrderDate != null)
            //{
            //    sqlStatement += "AND Order.OrderDate<=" + searchObject.ToOrderDate + Environment.NewLine;
            //}
            //execute
            result = Connection.Query<OrderEntity>(sqlStatement).ToList();
            return result;
        }

        public OrderEntity AddOrUpdateOrder(OrderEntity entityObject)
        {
            string sqlStatement = "";
            entityObject.CreatedDate = DateTime.Now;
            
            sqlStatement += "DECLARE @NewOrderId INT " + Environment.NewLine;
            //if insert
            if (entityObject.OrderId > 0)
            {
                sqlStatement += "UPDATE [Order] SET  " + Environment.NewLine +
                "OrderType=@OrderType," + Environment.NewLine +
                "BusinessId=@BusinessId," + Environment.NewLine +
                "IndustryId=@IndustryId," + Environment.NewLine +
                "CreatedBy=@CreatedBy," + Environment.NewLine +
                "ResponsibleBy=@ResponsibleBy," + Environment.NewLine +
                "OrderDate=@OrderDate," + Environment.NewLine +
                "CreatedDate=@CreatedDate," + Environment.NewLine +
                "CompanyId=@CompanyId," + Environment.NewLine +
                "LocationId=@LocationId," + Environment.NewLine +
                "OrderStatus=@OrderStatus," + Environment.NewLine +
                "CustomerCompanyId=@CustomerCompanyId," + Environment.NewLine +
                "CustomerContactId=@CustomerContactId," + Environment.NewLine +
                "OrderNumber=@OrderNumber," + Environment.NewLine +
                "Description=@Description" + Environment.NewLine +
                "WHERE OrderId=@OrderId " + Environment.NewLine +
                "SET @NewOrderId=@OrderId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO [Order](  " + Environment.NewLine +
                "OrderType," + Environment.NewLine +
                "BusinessId," + Environment.NewLine +
                "IndustryId," + Environment.NewLine +
                "CreatedBy," + Environment.NewLine +
                "ResponsibleBy, " + Environment.NewLine +
                "OrderDate," + Environment.NewLine +
                "CreatedDate," + Environment.NewLine +
                "CompanyId," + Environment.NewLine +
                "LocationId," + Environment.NewLine +
                "CustomerCompanyId," + Environment.NewLine +
                "CustomerContactId," + Environment.NewLine +
                "OrderStatus," + Environment.NewLine +
                "OrderNumber," + Environment.NewLine +
                "Description)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@OrderType," + Environment.NewLine +
                "@BusinessId," + Environment.NewLine +
                "@IndustryId," + Environment.NewLine +
                "@CreatedBy," + Environment.NewLine +
                "@ResponsibleBy," + Environment.NewLine +
                "@OrderDate," + Environment.NewLine +
                "@CreatedDate," + Environment.NewLine +
                "@CompanyId," + Environment.NewLine +
                "@LocationId," + Environment.NewLine +
                "@CustomerCompanyId," + Environment.NewLine +
                "@CustomerContactId," + Environment.NewLine +
                "@OrderStatus," + Environment.NewLine +
                "@OrderNumber," + Environment.NewLine +
                "@Description)" + Environment.NewLine +
                "SET @NewOrderId = (SELECT SCOPE_IDENTITY() AS OrderId) " + Environment.NewLine;

                sqlStatement += "UPDATE [Order] Set OrderNumber=(SELECT dbo.BuildOrderNumberForOrder(@NewOrderId)) WHERE OrderId=@NewOrderId " + Environment.NewLine;
            }

            sqlStatement += "SELECT " + Environment.NewLine +
                "[Order].OrderId," + Environment.NewLine +
                "[Order].OrderType," + Environment.NewLine +
                "[Order].BusinessId," + Environment.NewLine +
                "[Order].IndustryId," + Environment.NewLine +
                "[Order].CreatedBy," + Environment.NewLine +
                "[Order].ResponsibleBy," + Environment.NewLine +
                "[Order].OrderDate," + Environment.NewLine +
                "[Order].CreatedDate," + Environment.NewLine +
                "[Order].CompanyId," + Environment.NewLine +
                "[Order].LocationId," + Environment.NewLine +
                "[Order].CustomerCompanyId," + Environment.NewLine +
                "[Order].CustomerContactId," + Environment.NewLine +
                "[Order].OrderStatus," + Environment.NewLine +
                "[Order].OrderNumber," + Environment.NewLine +
                "[Order].Description" + Environment.NewLine +
                "FROM [Order] " + Environment.NewLine +
                "WHERE OrderId=@NewOrderId " + Environment.NewLine;

            //execute
            var result = Connection.Query<OrderEntity>(sqlStatement, new
            {
                OrderId = entityObject.OrderId,
                OrderType = entityObject.OrderType,
                BusinessId = entityObject.BusinessId,
                IndustryId = entityObject.IndustryId,
                CreatedBy = entityObject.CreatedBy,
                ResponsibleBy = entityObject.ResponsibleBy,
                OrderStatus = entityObject.OrderStatus,
                OrderDate = entityObject.OrderDate,
                CreatedDate = entityObject.CreatedDate,
                CompanyId = entityObject.CompanyId,
                LocationId = entityObject.LocationId,
                CustomerCompanyId = entityObject.CustomerCompanyId,
                CustomerContactId = entityObject.CustomerContactId,
                OrderNumber = entityObject.OrderNumber,
                Description = entityObject.Description
            }).ToList();

            if (result.Count > 0)
                entityObject = result[0];
            else
                entityObject = null;
            return entityObject;
        }
        public bool DeleteOrder(OrderEntity entityObject)
        {
            string sqlStatement = "UPDATE [Order] SET Deleted=1 WHERE OrderId=@OrderId  " + Environment.NewLine;

            //execute
            Connection.Execute(sqlStatement, new { OrderId = entityObject.OrderId });
            return true;
        }
        public List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject)
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
                "Orderline.PayDate," + Environment.NewLine +
                "Article.CategoryId," + Environment.NewLine +
                "Article.ArticleNo," + Environment.NewLine +
                "Article.Description," + Environment.NewLine +
                "Article.Unit" + Environment.NewLine +
                "FROM Orderline JOIN Article ON Orderline.ArticleId=Article.ArticleId " + Environment.NewLine +
                "WHERE Deleted=0 AND Orderline.OrderId=@OrderId" + Environment.NewLine;
            
            //execute
            result = Connection.Query<OrderlineEntity>(sqlStatement, new { OrderId = searchObject.OrderId }).ToList();
            return result;
        }
        public OrderlineEntity AddOrUpdateOrderline(OrderlineEntity entityObject)
        {
            string sqlStatement = "";

            sqlStatement += "DECLARE @NewOrderlineId INT " + Environment.NewLine;
            //if insert
            if (entityObject.OrderlineId > 0)
            {
                entityObject.ModifiedDate = DateTime.Now;

                sqlStatement += "UPDATE Orderline SET  " + Environment.NewLine +
                //"OrderId=@OrderId" + Environment.NewLine +
                "Commission=@Commission, " + Environment.NewLine +
                "ArticleId=@ArticleId, " + Environment.NewLine +
                "Quantity=@Quantity, " + Environment.NewLine +
                "Price=@Price, " + Environment.NewLine +
                "CreatedBy=@CreatedBy, " + Environment.NewLine +
                "PayDate=@PayDate, " + Environment.NewLine +
                "CreatedDate=@CreatedDate, " + Environment.NewLine +
                "ModifiedBy=@ModifiedBy, " + Environment.NewLine +
                "ModifiedDate=@ModifiedDate " + Environment.NewLine +
                "WHERE OrderlineId=@OrderlineId " + Environment.NewLine +
                "SET @NewOrderlineId = @OrderlineId " + Environment.NewLine;
            }
            else
            {
                entityObject.CreatedDate = DateTime.Now;
                entityObject.ModifiedDate = DateTime.Now;

                sqlStatement += "INSERT INTO Orderline(  " + Environment.NewLine +
                "OrderId," + Environment.NewLine +
                "Commission," + Environment.NewLine +
                "ArticleId," + Environment.NewLine +
                "Quantity," + Environment.NewLine +
                "Price," + Environment.NewLine +
                "CreatedBy," + Environment.NewLine +
                "PayDate," + Environment.NewLine +
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
                "@PayDate," + Environment.NewLine +
                "@CreatedDate," + Environment.NewLine +
                "@ModifiedBy," + Environment.NewLine +
                "@ModifiedDate)" + Environment.NewLine +
                "SET @NewOrderlineId = (SELECT SCOPE_IDENTITY()) " + Environment.NewLine;

                //also insert default loans if needed
                sqlStatement += "INSERT INTO Loan(OrderlineId,ArticleId,Quantity)" + Environment.NewLine;
                sqlStatement += "SELECT OrderlineId,RelatedArticleId,0 AS Quantity FROM Orderline JOIN ArticleRelation ON Orderline.ArticleId=ArticleRelation.ArticleId WHERE OrderlineId=@NewOrderlineId " + Environment.NewLine;
            }

            sqlStatement += "SELECT " + Environment.NewLine +
                "Orderline.OrderlineId," + Environment.NewLine +
                "Orderline.OrderId," + Environment.NewLine +
                "Orderline.Commission," + Environment.NewLine +
                "Orderline.ArticleId," + Environment.NewLine +
                "Orderline.Quantity," + Environment.NewLine +
                "Orderline.Price," + Environment.NewLine +
                "Orderline.CreatedBy," + Environment.NewLine +
                "Orderline.PayDate," + Environment.NewLine +
                "Orderline.CreatedDate," + Environment.NewLine +
                "Orderline.ModifiedBy," + Environment.NewLine +
                "Orderline.ModifiedDate," + Environment.NewLine +
                "Article.CategoryId," + Environment.NewLine +
                "Article.ArticleNo," + Environment.NewLine +
                "Article.Description," + Environment.NewLine +
                "Article.Unit" + Environment.NewLine +                
                "FROM Orderline JOIN Article ON Orderline.ArticleId=Article.ArticleId " + Environment.NewLine +
                "WHERE Orderline.OrderlineId=@NewOrderlineId" + Environment.NewLine;

            //execute
            var result = Connection.Query<OrderlineEntity>(sqlStatement, new
            {
                OrderlineId = entityObject.OrderlineId,
                OrderId = entityObject.OrderId,
                Commission = entityObject.Commission,
                ArticleId = entityObject.ArticleId,
                Quantity = entityObject.Quantity,
                Price = entityObject.Price,
                CreatedBy = entityObject.CreatedBy,
                CreatedDate = entityObject.CreatedDate,
                PayDate = entityObject.PayDate,
                ModifiedBy = entityObject.ModifiedBy,
                ModifiedDate = entityObject.ModifiedDate,
                CategoryId = entityObject.CategoryId,
                ArticleNo = entityObject.ArticleNo,

                Description = entityObject.Description,
                Unit = entityObject.Unit
            }).ToList();

            if (result.Count > 0)
                entityObject = result[0];
            else
                entityObject = null;
            return entityObject;
        }
        public bool DeleteOrderline(OrderlineEntity entityObject)
        {
            string sqlStatement = "DELETE FROM Orderline WHERE OrderlineId=@OrderlineId  " + Environment.NewLine;

            //execute
            var result = Connection.Query<OrderlineEntity>(sqlStatement, new
            {
                OrderlineId = entityObject.OrderlineId,
                OrderId = entityObject.OrderId,
                Commission = entityObject.Commission,
                ArticleId = entityObject.ArticleId,
                Quantity = entityObject.Quantity,
                Price = entityObject.Price,
                CreatedBy = entityObject.CreatedBy,
                CreatedDate = entityObject.CreatedDate,
                PayDate = entityObject.PayDate,
                ModifiedBy = entityObject.ModifiedBy,
                ModifiedDate = entityObject.ModifiedDate,
                CategoryId = entityObject.CategoryId,
                ArticleNo = entityObject.ArticleNo,

                Description = entityObject.Description,
                Unit = entityObject.Unit
            }).ToList();

            if (result.Count > 0)
                entityObject = result[0];
            else
                entityObject = null;
            return true;
        }

        public List<LoanEntity> GetLoansForOrderline(OrderlineEntity searchObject)
        {
            List<LoanEntity> result = null;
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Loan.LoanId," + Environment.NewLine +
                "Loan.OrderlineId," + Environment.NewLine +
                "Loan.Quantity," + Environment.NewLine +
                "Loan.ArticleId," + Environment.NewLine +
                "Article.CategoryId," + Environment.NewLine +
                "Article.ArticleNo," + Environment.NewLine +
                "Article.Description," + Environment.NewLine +
                "Article.Unit " + Environment.NewLine +                
                "FROM Loan JOIN Article ON Loan.ArticleId=Article.ArticleId " + Environment.NewLine +
                "WHERE Loan.OrderlineId=@OrderlineId" + Environment.NewLine;

            //execute
            result = Connection.Query<LoanEntity>(sqlStatement, new { OrderlineId = searchObject.OrderlineId }).ToList();
            return result;
        }
        public LoanEntity AddOrUpdateLoan(LoanEntity entityObject)
        {
            string sqlStatement = "";

            sqlStatement += "DECLARE @NewLoanId INT " + Environment.NewLine;
            //if insert
            if (entityObject.LoanId > 0)
            {
                sqlStatement += "UPDATE Loan SET  " + Environment.NewLine +
                    //"OrderId=@OrderId" + Environment.NewLine +
                "ArticleId=@ArticleId," + Environment.NewLine +
                "Quantity=@Quantity" + Environment.NewLine +
                "WHERE LoanId=@LoanId " + Environment.NewLine +
                "SET @NewLoanId = @LoanId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Loan(  " + Environment.NewLine +
                "OrderlineId," + Environment.NewLine +
                "ArticleId," + Environment.NewLine +
                "Quantity)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@OrderlineId," + Environment.NewLine +
                "@ArticleId," + Environment.NewLine +
                "@Quantity)" + Environment.NewLine +
                "SET @NewLoanId = (SELECT SCOPE_IDENTITY()) " + Environment.NewLine;
            }

            sqlStatement += "SELECT " + Environment.NewLine +
                "Loan.LoanId," + Environment.NewLine +
                "Loan.Quantity," + Environment.NewLine +
                "Loan.ArticleId," + Environment.NewLine +
                "Article.CategoryId," + Environment.NewLine +
                "Article.ArticleNo," + Environment.NewLine +
                "Article.Description," + Environment.NewLine +
                "Article.Unit " + Environment.NewLine +
                "FROM Loan JOIN Article ON Loan.ArticleId=Article.ArticleId " + Environment.NewLine +
                "WHERE Loan.LoanId=@NewLoanId" + Environment.NewLine;

            //execute
            var result = Connection.Query<LoanEntity>(sqlStatement, new
            {
                OrderlineId = entityObject.OrderlineId,
                ArticleId = entityObject.ArticleId,
                Quantity = entityObject.Quantity,
                LoanId = entityObject.LoanId
            }).ToList();

            if (result.Count > 0)
                entityObject = result[0];
            else
                entityObject = null;
            return entityObject;
        }
        public bool DeleteLoan(LoanEntity entityObject)
        {
            string sqlStatement = "DELETE FROM Loan WHERE LoanId=@LoanId  " + Environment.NewLine;

            //execute
            Connection.Execute(sqlStatement, new { LoanId = entityObject.LoanId });
            return true;
        }
    
    }
}
