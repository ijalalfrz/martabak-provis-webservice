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

        public bool Delete(MenuModel plg)
        {
            db.Open();
            var data = db.connection.Delete<MenuModel>(plg);
            db.Close();
            return true;
        }

        public List<MenuModel> GetAll()
        {
            throw new NotImplementedException();
        }


        public bool Insert(MenuModel plg)
        {
            throw new NotImplementedException();
        }

        public bool Update(MenuModel plg)
        {
            throw new NotImplementedException();
        }

        public MenuModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
