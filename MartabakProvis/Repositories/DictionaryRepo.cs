using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MartabakProvis.Helper;
using MartabakProvis.Models;

namespace MartabakProvis.Repositories
{
    public class DictionaryRepo
    {
        Database db;

        public DictionaryRepo()
        {
            db = new Database();
        }

        public List<string> GetAllTableName()
        {
            try
            {
                db.Open();

                var selectSql = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'martabakprovis'";
                var data = db.connection.Query<string>(selectSql).ToList();
                db.Close();

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<DictionaryModel> GetDictionary(string table)
        {
            try
            {
                db.Open();

                var selectSql = "SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" +table+ "'";

                var data = db.connection.Query<DictionaryModel>(selectSql).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return null;
            }
        } 
    }
}
