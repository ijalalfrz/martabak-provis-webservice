using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartabakProvis.Interface;
using MartabakProvis.Models;
using MartabakProvis.Helper;
using Dapper.Contrib.Extensions;
using Dapper;

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
            try
            {
                db.Open();
                var data = db.connection.Delete<TokoModel>(pembeli);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public List<TokoModel> GetAll()
        {
            try
            {
                db.Open();
                var data = db.connection.GetAll<TokoModel>().ToList();
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public bool Insert(TokoModel pembeli)
        {
            try
            {
                db.Open();
                var data = db.connection.Insert<TokoModel>(pembeli);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public int? GetLastId()
        {
            try
            {
                db.Open();
                string sql = "SELECT * FROM t_toko ORDER BY id_toko DESC LIMIT 1";
                var data = db.connection.QuerySingleOrDefault<TokoModel>(sql);
                db.Close();
                return data.id_toko;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public bool InsertAll(TokoSemuaModel input)
        {
            try
            {
                db.Open();
                var dataToko = db.connection.Insert<TokoModel>(input.toko);
                int? lastid = GetLastId();

                input.user.id_toko = lastid;

                var dataUser = db.connection.Insert<UserModel>(input.user);
                db.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Update(TokoModel pembeli)
        {
            try
            {
                db.Open();
                var data = db.connection.Update<TokoModel>(pembeli);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public TokoModel GetById(int id)
        {
            try
            {
                db.Open();
                var data = db.connection.Get<TokoModel>(id);
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
