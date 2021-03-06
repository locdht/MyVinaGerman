﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.ReportEntity;

namespace VinaGerman.Business.Implementation
{
    public class ReportBL : IReportBL
    {
        public HeaderReportEntity GetHeaderReport(int companyId, int locationId, string reportName)
        {
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    HeaderReportEntity result = new HeaderReportEntity();
                    //get company information
                    VinaGerman.Entity.DatabaseEntity.CompanyEntity objCompany = db.Resolve<ICompanyDB>().GetCompanyById(companyId);
                    //get location information
                    LocationEntity objLocation = null;
                    if (locationId > 0)
                    {
                        objLocation = db.Resolve<ILocationDB>().GetLocationById(locationId);
                    }
                    if (objLocation != null && objLocation.LocationId > 0)
                    {
                        result.Description = objLocation.Description;
                        result.Address = objLocation.Address;
                    }
                    else if (objCompany != null && objCompany.CompanyId > 0)
                    {
                        result.Description = objCompany.Description;
                        result.Address = objCompany.Address;
                    }
                    //get official note
                    VinaGerman.Entity.DatabaseEntity.OfficialNoteEntity note = db.Resolve<IReportDB>().GetOfficialNoteByReportName(reportName);
                    if (note != null)
                    {
                        result.OfficialNoteCode = note.Code;
                        result.OfficialNoteDescription = note.Description;
                    }
                    return result;
                }
                finally
                {
                    db.CloseConnection();
                }
            }            
        }
    }
}
