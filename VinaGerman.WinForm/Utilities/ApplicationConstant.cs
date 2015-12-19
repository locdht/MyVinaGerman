using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.WinForm.Utilities
{
    public enum enumView
    {
        Logon,
        CompanyManagement,
        CategoryManagement,
        BusinessManagement,
        IndustryManagement,
        ArticleManagement,
        DepartmentManagement,   
        PurchaseOrderManagement,
        PurchaseOrderDetail,
        SaleOrderManagement,
        SaleOrderDetail,
        LocationManagement,
        ContactManagement
    }
    public enum enumOrderStatus
    {
        Ready = 1,
        Approved = 2,
        Processed = 3
    }

    public enum enumOrderType
    {
        Purchase=1,
        Sale=2
    }
}
