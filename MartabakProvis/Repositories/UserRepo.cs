using Dapper;
using Dapper.Contrib.Extensions;
using MartabakProvis.Helper;
using MartabakProvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartabakProvis.Repositories
{
    public class UserRepo
    {
        Database db;

        public UserRepo()
        {
            db = new Database();
        }

        public List<UserModel> GetAll()
        {
            db.Open();
            var data = db.connection.GetAll<UserModel>().ToList();

            db.Close();
            return data;
        }

        public UserModel GetById(int id)
        {
            db.Open();
            var data = db.connection.Get<UserModel>(id);
            db.Close();
            return data;
        }

        public UserModel GetByUsername(string uname)
        {
            db.Open();
            var selectSql = "SELECT * FROM t_user WHERE username = @username";
            UserModel menu = new UserModel();
            var data = db.connection.QuerySingle<UserModel>(selectSql, new
            {
                username = uname
            });
            db.Close();
            return data;
        }

        public bool Insert(UserModel user)
        {
            db.Open();
            var data = db.connection.Insert<UserModel>(user);
            db.Close();
            return true;
        }

        public bool Update(UserModel user)
        {
            db.Open();
            var data = db.connection.Update<UserModel>(user);
            db.Close();
            return true;
        }

        public bool Delete(UserModel user)
        {
            db.Open();
            var data = db.connection.Delete<UserModel>(user);
            db.Close();
            return true;
        }


    }
}
