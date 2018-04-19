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
    public class PembeliRepo : InterRepo<PembeliModel>
    {
        Database db;

        public PembeliRepo()
        {
            db = new Database();
        }


        public bool Delete(PembeliModel pembeli)
        {
            db.Open();
            var data = db.connection.Delete<PembeliModel>(pembeli);
            db.Close();
            return true;
        }

        public List<PembeliModel> GetAll()
        {
            db.Open();
            var data = db.connection.GetAll<PembeliModel>().ToList();
            db.Close();
            return data;
        }

        public bool Insert(PembeliModel pembeli)
        {
            db.Open();
            var data = db.connection.Insert<PembeliModel>(pembeli);
            db.Close();
            return true;
        }

        public bool Update(PembeliModel pembeli)
        {
            db.Open();
            var data = db.connection.Update<PembeliModel>(pembeli);
            db.Close();
            return true;
        }

        public PembeliModel GetById(int id)
        {
            db.Open();
            var data = db.connection.Get<PembeliModel>(id);
            db.Close();
            return data;
        }
    }
}
