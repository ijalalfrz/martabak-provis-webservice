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


    }
}
