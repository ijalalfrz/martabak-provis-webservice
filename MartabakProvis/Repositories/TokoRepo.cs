using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartabakProvis.Interface;
using MartabakProvis.Models;
using MartabakProvis.Helper;
using Dapper.Contrib.Extensions;

namespace MartabakProvis.Repositories
{
    public class TokoRepo : InterRepo<TokoModel>
    {
        Database db;

        public TokoRepo()
        {
            db = new Database();
        }


        public bool Delete(TokoModel pembeli)
        {
            db.Open();
            var data = db.connection.Delete<TokoModel>(pembeli);
            db.Close();
            return true;
        }

        public List<TokoModel> GetAll()
        {
            db.Open();
            var data = db.connection.GetAll<TokoModel>().ToList();
            db.Close();
            return data;
        }

        public bool Insert(TokoModel pembeli)
        {
            db.Open();
            var data = db.connection.Insert<TokoModel>(pembeli);
            db.Close();
            return true;
        }

        public bool Update(TokoModel pembeli)
        {
            db.Open();
            var data = db.connection.Update<TokoModel>(pembeli);
            db.Close();
            return true;
        }

        public TokoModel GetById(int id)
        {
            db.Open();
            var data = db.connection.Get<TokoModel>(id);
            db.Close();
            return data;
        }
    }
}
