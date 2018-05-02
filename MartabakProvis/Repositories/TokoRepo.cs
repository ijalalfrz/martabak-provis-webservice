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
        UserModel user;
        UserRepo urepo;
       
        
        

        public TokoRepo()
        {
            db = new Database();
            user = new UserModel();
            urepo = new UserRepo();
        }


        public bool Delete(TokoModel toko)
        {
            try
            {
                db.Open();
                user = urepo.GetByIdToko(toko.id_toko);
                urepo.Delete(user);

                var data = db.connection.Delete<TokoModel>(toko);

                

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
            }catch (Exception e)
            {
                return null;
            }
        }

        public TokoViewModel GetByIdWithUser(int id)
        {
            try
            {
                db.Open();
                var dataToko = db.connection.Get<TokoModel>(id);
                user = urepo.GetByIdToko(dataToko.id_toko);

                TokoViewModel data = new TokoViewModel();
                data.toko = dataToko;
                data.user = user;

                db.Close();

                return data;
            }catch (Exception e)
            {
                return null;
            }
        }


        public List<TokoViewModel> GetAllWithUser()
        {
            try
            {
                db.Open();

                var toko = db.connection.GetAll<TokoModel>().ToList();

                List<TokoViewModel> list = new List<TokoViewModel>();
                

                foreach (var all in toko)
                {
                    var us = urepo.GetByIdToko(all.id_toko);

                    list.Add(new TokoViewModel { toko = all, user = us });

                }



                db.Close();
                return list;
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

        public bool InsertAll(TokoViewModel input)
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
