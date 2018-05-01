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
