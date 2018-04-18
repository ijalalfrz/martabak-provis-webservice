using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartabakProvis.Helper;
using MartabakProvis.Models;
using MartabakProvis.Interface;
using Dapper.Contrib.Extensions;

namespace MartabakProvis.Repositories
{
    public class MenuRepo : InterRepo<MenuModel>
    {
        Database db;

        public MenuRepo()
        {
            db = new Database();
        }

        public MenuModel GetByid(int id)
        {
            db.Open();
            var data = db.connection.Get<MenuModel>(id);
            db.Close();
            return data;
        }

        public bool Delete(MenuModel menu)
        {
            db.Open();
            var data = db.connection.Delete<MenuModel>(menu);
            db.Close();
            return true;
        }

        public List<MenuModel> GetAll()
        {
            db.Open();
            var data = db.connection.GetAll<MenuModel>().ToList();
            db.Close();
            return data;
        }


        public bool Insert(MenuModel menu)
        {
            db.Open();
            var data = db.connection.Insert<MenuModel>(menu);
            db.Close();
            return true;
        }

        public bool Update(MenuModel menu)
        {
            db.Open();
            var data = db.connection.Update<MenuModel>(menu);
            db.Close();
            return true;
        }

        public MenuModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
