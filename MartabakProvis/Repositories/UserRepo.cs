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
            try
            {
                db.Open();
                var data = db.connection.GetAll<UserModel>().ToList();

                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public UserModel GetById(int id)
        {
            try
            {
                db.Open();
                var data = db.connection.Get<UserModel>(id);
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public UserModel GetByUsername(string uname)
        {


            db.Open();
            var selectSql = "SELECT * FROM t_user WHERE username = '" + uname + "'";
            UserModel menu = new UserModel();
            var data = db.connection.QueryFirst<UserModel>(selectSql, new
            {
                username = uname
            });
            db.Close();
            return data;


        }

        public UserModel GetByIdToko(int id)
        {
            try
            {
                db.Open();
                var sql = "SELECT * FROM t_user WHERE id_toko = " + id;
                var data = db.connection.QueryFirst<UserModel>(sql, new
                {
                    id_toko = id
                });
                db.Close();

                return data;

            }catch(Exception e)
            {
                return null;
            }
        }

        public bool Insert(UserModel user)
        {
            try
            {
                db.Open();
                var data = db.connection.Insert<UserModel>(user);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(UserModel user)
        {
            try
            {
                db.Open();
                var data = db.connection.Update<UserModel>(user);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Delete(UserModel user)
        {
            try
            {
                db.Open();
                var data = db.connection.Delete<UserModel>(user);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }


    }
}
