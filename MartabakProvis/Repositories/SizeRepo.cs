using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartabakProvis.Helper;
using MartabakProvis.Models;
using MartabakProvis.Interface;
using Dapper.Contrib.Extensions;
using Dapper;

namespace MartabakProvis.Repositories
{
    public class SizeRepo : InterRepo<SizeModel>
    {
        Database db;

        public SizeRepo()
        {
            db = new Database();
        }

        public bool Insert(SizeModel size)
        {
            db.Open();
            var data = db.connection.Insert<SizeModel>(size);
            db.Close();
            return true;
        }
        public bool Update(SizeModel size)
        {
            db.Open();
            var data = db.connection.Update<SizeModel>(size);
            db.Close();
            return true;

        }
        public bool Delete(SizeModel size)
        {
            db.Open();
            var data = db.connection.Delete<SizeModel>(size);
            db.Close();
            return true;

        }
        public SizeModel GetById(int id)
        {
            db.Open();
            var data = db.connection.Get<SizeModel>(id);
            db.Close();
            return data;

        }
        public List<SizeModel> GetAll()
        {
            db.Open();
            var data = db.connection.GetAll<SizeModel>().ToList();

            db.Close();
            return data;

        }
    }
}
