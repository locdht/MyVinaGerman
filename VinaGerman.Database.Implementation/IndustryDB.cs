﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;
using Dapper;
namespace VinaGerman.Database.Implementation
{
    public class IndustryDB : BaseDB, IIndustryDB
    {
        public List<IndustryEntity> SearchIndustry(IndustrySearchEntity searchObject)
        {
            List<IndustryEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Industry.IndustryId," + Environment.NewLine +
                "Industry.Description," + Environment.NewLine +
                "Industry.Deleted" + Environment.NewLine +
                "FROM Industry " + Environment.NewLine +
                "WHERE Deleted=0 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (Description LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            result = Connection.Query<IndustryEntity>(sqlStatement,null, Transaction).ToList();
            return result;
        }

        public IndustryEntity AddOrUpdateIndustry(IndustryEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.IndustryId > 0)
            {
                sqlStatement += "UPDATE Industry SET  " + Environment.NewLine +
                "Description=@Description," + Environment.NewLine +
                "Deleted=@Deleted" + Environment.NewLine +
                "WHERE IndustryId=@IndustryId " + Environment.NewLine +
                "SELECT @IndustryId AS IndustryId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Industry(  " + Environment.NewLine +
                "Description," + Environment.NewLine +
                "Deleted)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@Description," + Environment.NewLine +
                "@Deleted)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS IndustryId" + Environment.NewLine;
            }

            //execute
            entityObject.IndustryId = Connection.ExecuteScalar<int>(sqlStatement, new
            {
                IndustryId = entityObject.IndustryId,
                Description = entityObject.Description,
                Deleted = (entityObject.Deleted ? 1 : 0)
            }, Transaction);
            return entityObject;
        }
        public bool DeleteIndustry(IndustryEntity entityObject)
        {
            string sqlStatement = "UPDATE Industry SET Deleted=1 WHERE IndustryId=@IndustryId  " + Environment.NewLine;

            //execute
            Connection.Execute(sqlStatement, new { IndustryId = entityObject.IndustryId }, Transaction);
            return true;
        }
    }
}
