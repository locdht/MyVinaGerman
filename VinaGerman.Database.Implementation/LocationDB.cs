﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;
using Dapper;
namespace VinaGerman.Database.Implementation
{
    public class LocationDB : BaseDB, ILocationDB
    {
        public LocationEntity GetLocationById(int locationId)
        {
            LocationEntity result = null;
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Location.LocationId," + Environment.NewLine +
                "Location.Address," + Environment.NewLine +
                "Location.Description," + Environment.NewLine +
                "Location.CompanyId," + Environment.NewLine +
                "Location.Deleted" + Environment.NewLine +
                "FROM Location " + Environment.NewLine +
                "WHERE LocationId=@LocationId " + Environment.NewLine;
        
            //execute
            result = Connection.Query<LocationEntity>(sqlStatement, new { LocationId = locationId }, Transaction).FirstOrDefault();
            return result;
        }
        public List<LocationEntity> SearchLocation(LocationSearchEntity searchObject)
        {
            List<LocationEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Location.LocationId," + Environment.NewLine +
                "Location.Address," + Environment.NewLine +
                "Location.Description," + Environment.NewLine +
                "Company.Description as CompanyName," + Environment.NewLine +
                "Location.CompanyId," + Environment.NewLine +
                "Location.Deleted" + Environment.NewLine +
                "FROM Location JOIN Company ON Location.CompanyId=Company.CompanyId " + Environment.NewLine +
                "WHERE Location.Deleted=0 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (Description LIKE N'%" + searchObject.SearchText + "%' OR Address LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            result = Connection.Query<LocationEntity>(sqlStatement, null, Transaction).ToList();
            return result;
        }

        public LocationEntity AddOrUpdateLocation(LocationEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.LocationId > 0)
            {
                sqlStatement += "UPDATE Location SET  " + Environment.NewLine +
                "Address=@Address," + Environment.NewLine +
                "Description=@Description," + Environment.NewLine +
                "CompanyId=@CompanyId," + Environment.NewLine +
                "Deleted=@Deleted" + Environment.NewLine +
                "WHERE LocationId=@LocationId " + Environment.NewLine +
                "SELECT @LocationId AS LocationId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Location(  " + Environment.NewLine +
                "Address," + Environment.NewLine +
                "Description," + Environment.NewLine +
                "CompanyId," + Environment.NewLine +
                "Deleted)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@Address," + Environment.NewLine +
                "@Description," + Environment.NewLine +
                "@CompanyId," + Environment.NewLine +
                "@Deleted)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS LocationId" + Environment.NewLine;
            }

            //execute
            entityObject.LocationId = Connection.ExecuteScalar<int>(sqlStatement, new
            {
                LocationId = entityObject.LocationId,
                Phone = entityObject.Address,
                Description = entityObject.Description,
                CompanyId = entityObject.CompanyId,
                Address = entityObject.Address,
                Deleted = (entityObject.Deleted ? 1 : 0)
            }, Transaction);
            return entityObject;
        }
        public bool DeleteLocation(LocationEntity entityObject)
        {
            string sqlStatement = "UPDATE Location SET Deleted=1 WHERE LocationId=@LocationId  " + Environment.NewLine;

            //execute
            Connection.Execute(sqlStatement, new { LocationId = entityObject.LocationId }, Transaction);
            return true;
        }
    }
}
