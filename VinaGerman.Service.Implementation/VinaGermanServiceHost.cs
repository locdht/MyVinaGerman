using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Business;
using VinaGerman.Business.Implementation;
using VinaGerman.Database;
using VinaGerman.Database.Implementation;
using VinaGerman.Entity;
using VinaGerman.Wcf.Security.Server;

namespace VinaGerman.Service.Implementation
{
    public class VinaGermanServiceHost : ServiceHost
    {
        public VinaGermanServiceHost(object singletonInstance, params Uri[] baseAddresses)
            : base(singletonInstance, baseAddresses) { }

        public VinaGermanServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses) { }

        protected override void InitializeRuntime()
        {
            RegisterImplementation();            
            base.InitializeRuntime();
        }

        #region Register implementation
        private void RegisterImplementation()
        {            
            Factory.Register<IUsernamePasswordValidator, CustomUsernamePasswordValidator>();

            //business layer
            Factory.Register<IUserBL, UserBL>();
            Factory.Register<ICompanyBL, CompanyBL>();
            Factory.Register<ICategoryBL, CategoryBL>();
            Factory.Register<IBusinessBL, BusinessBL>();
            Factory.Register<IIndustryBL, IndustryBL>();
            Factory.Register<IArticleBL, ArticleBL>();
            Factory.Register<IDepartmentBL, DepartmentBL>();
            Factory.Register<ILocationBL, LocationBL>();
            Factory.Register<IContactBL, ContactBL>();
            Factory.Register<IOrderBL, OrderBL>();
            //database layer
            Factory.Register<IUserDB, UserDB>();
            Factory.Register<ICompanyDB, CompanyDB>();
            Factory.Register<ICategoryDB, CategoryDB>();
            Factory.Register<IBusinessDB, BusinessDB>();
            Factory.Register<IIndustryDB, IndustryDB>();
            Factory.Register<IArticleDB, ArticleDB>();
            Factory.Register<IDepartmentDB, DepartmentDB>();
            Factory.Register<ILocationDB, LocationDB>();
            Factory.Register<IContactDB, ContactDB>();
            Factory.Register<IOrderDB, OrderDB>();
            //EntityHelper.GetFactoryInstance().Register<ICategoryTypeDB, CategoryTypeDB>();
            //EntityHelper.GetFactoryInstance().Register<IPersonnelDB, PersonnelDB>();
        }      
        #endregion
    }
}
