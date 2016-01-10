using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business.Implementation
{
    public class DepartmentBL : BaseBL, IDepartmentBL
    {
        public List<DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IDepartmentDB>().SearchDepartment(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public DepartmentEntity AddOrUpdateDepartment(DepartmentEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IDepartmentDB>().AddOrUpdateDepartment(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }               
        }
        public bool DeleteDepartment(DepartmentEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IDepartmentDB>().DeleteDepartment(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }              
        }
    }
}
