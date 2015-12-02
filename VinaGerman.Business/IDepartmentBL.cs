using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business
{
    public interface IDepartmentBL
    {
        List<DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject);
        DepartmentEntity AddOrUpdateDepartment(DepartmentEntity entityObject);
        bool DeleteDepartment(DepartmentEntity entityObject);
    }
}
