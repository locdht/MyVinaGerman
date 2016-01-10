using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business.Implementation
{
    public class CompanyBL : BaseBL, ICompanyBL
    {
        public List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ICompanyDB>().SearchCompanies(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }              
        }
        public CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ICompanyDB>().AddOrUpdateCompany(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public bool DeleteCompany(CompanyEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ICompanyDB>().DeleteCompany(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
    }
}
