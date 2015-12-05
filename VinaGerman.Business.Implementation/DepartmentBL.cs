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
            return Factory.Resolve<IDepartmentDB>().SearchDepartment(searchObject);
        }
        public DepartmentEntity AddOrUpdateDepartment(DepartmentEntity entityObject)
        {
            return Factory.Resolve<IDepartmentDB>().AddOrUpdateDepartment(entityObject);
        }
        public bool DeleteDepartment(DepartmentEntity entityObject)
        {
            return Factory.Resolve<IDepartmentDB>().DeleteDepartment(entityObject);
        }
    }
}
