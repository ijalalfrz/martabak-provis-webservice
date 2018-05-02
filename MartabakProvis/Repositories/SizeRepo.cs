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
            try
            {
                db.Open();
                var data = db.connection.Insert<SizeModel>(size);
                db.Close();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        public bool Update(SizeModel size)
        {
            try
            {
                db.Open();
                var data = db.connection.Update<SizeModel>(size);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            

        }
        public bool Delete(SizeModel size)
        {
            try
            {
                db.Open();
                var data = db.connection.Delete<SizeModel>(size);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            

        }
        public SizeModel GetById(int id)
        {
            try
            {
                db.Open();
                var data = db.connection.Get<SizeModel>(id);
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            

        }

        public List<SizeModel> GetByIdMenu(int id)
        {
            try
            {
                db.Open();
                var sql = "SELECT * FROM t_size WHERE id_menu = " + id;
                var data = db.connection.Query<SizeModel>(sql, new
                {
                    id_menu = id
                }).ToList();
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        public List<SizeModel> GetAll()
        {
            try
            {
                db.Open();
                var data = db.connection.GetAll<SizeModel>().ToList();

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
