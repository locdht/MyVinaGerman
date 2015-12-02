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
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Wcf.Security;
using VinaGerman.Wcf.Security.Server;

namespace VinaGerman.Service.Implementation
{
    [PersonnelInspectorBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class BaseDataSvc : IBaseDataSvc
    {
        #region Category
        public List<CategoryEntity> SearchCategories(CategorySearchEntity searchObject)
        {   
            return Factory.Resolve<ICategoryBL>().SearchCategories(searchObject);
        }

        public CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject)
        {
            return Factory.Resolve<ICategoryBL>().AddOrUpdateCategory(entityObject);
        }

        public bool DeleteCategory(CategoryEntity entityObject)
        {
            return Factory.Resolve<ICategoryBL>().DeleteCategory(entityObject);
        }
        #endregion

        #region Business
        public List<BusinessEntity> SearchBusiness(BusinessSearchEntity searchObject)
        {
            return Factory.Resolve<IBusinessBL>().SearchBusiness(searchObject);
        }

        public BusinessEntity AddOrUpdateBusiness(BusinessEntity entityObject)
        {
            return Factory.Resolve<IBusinessBL>().AddOrUpdateBusiness(entityObject);
        }

        public bool DeleteBusiness(BusinessEntity entityObject)
        {
            return Factory.Resolve<IBusinessBL>().DeleteBusiness(entityObject);
        }
        #endregion

        #region Industry
        public List<IndustryEntity> SearchIndustry(IndustrySearchEntity searchObject)
        {
            return Factory.Resolve<IIndustryBL>().SearchIndustry(searchObject);
        }

        public IndustryEntity AddOrUpdateIndustry(IndustryEntity entityObject)
        {
            return Factory.Resolve<IIndustryBL>().AddOrUpdateIndustry(entityObject);
        }

        public bool DeleteIndustry(IndustryEntity entityObject)
        {
            return Factory.Resolve<IIndustryBL>().DeleteIndustry(entityObject);
        }
        #endregion

        #region Article
        public List<ArticleEntity> SearchArticle(ArticleSearchEntity searchObject)
        {
            return Factory.Resolve<IArticleBL>().SearchArticle(searchObject);
        }

        public ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject)
        {
            return Factory.Resolve<IArticleBL>().AddOrUpdateArticle(entityObject);
        }

        public bool DeleteArticle(ArticleEntity entityObject)
        {
            return Factory.Resolve<IArticleBL>().DeleteArticle(entityObject);
        }
        public List<ArticleRelationEntity> GetArticleRelationsForArticle(ArticleEntity searchObject)
        {
            return Factory.Resolve<IArticleBL>().GetArticleRelationsForArticle(searchObject);
        }
        public ArticleRelationEntity AddOrUpdateArticleRelation(ArticleRelationEntity entityObject)
        {
            return Factory.Resolve<IArticleBL>().AddOrUpdateArticleRelation(entityObject);
        }
        public bool DeleteArticleRelation(ArticleRelationEntity entityObject)
        {
            return Factory.Resolve<IArticleBL>().DeleteArticleRelation(entityObject);
        }
        #endregion
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
