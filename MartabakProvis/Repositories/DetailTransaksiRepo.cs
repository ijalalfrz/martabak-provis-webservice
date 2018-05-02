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
    public class DetailTransaksiRepo : InterRepo<DetailTransaksiModel>
    {
        Database db;
        MenuRepo mrepo;
        MenuModel menu;
        SizeRepo srepo;
        SizeModel size;

        public DetailTransaksiRepo()
        {
            db = new Database();

            mrepo = new MenuRepo();
            menu = new MenuModel();

            srepo = new SizeRepo();
            size = new SizeModel();
        }

        public List<DetailTransaksiModel> GetAll()
        {
            try
            {
                db.Open();
                var data = db.connection.GetAll<DetailTransaksiModel>().ToList();

                foreach (var all in data)
                {
                    menu = mrepo.GetById(all.id_menu);
                    all.topping = menu.topping;

                    size = srepo.GetById(all.id_size);
                    all.size = size.size;

                }
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public List<DetailTransaksiModel> GetByIdTransaksi(int id)
        {
            try
            {
                db.Open();
                var sql = "SELECT * FROM t_detail_transaksi WHERE id_transaksi = " + id;
                var data = db.connection.Query<DetailTransaksiModel>(sql, new
                {
                    id_transaksi = id
                }).ToList();

                foreach (var all in data)
                {
                    menu = mrepo.GetById(all.id_menu);
                    all.topping = menu.topping;

                    size = srepo.GetById(all.id_size);
                    all.size = size.size;

                }

                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public List<DetailTransaksiModel> GetByIdMenu(int id)
        {
            try
            {
                db.Open();
                var sql = "SELECT * FROM t_detail_transaksi WHERE id_menu = " + id;
                var data = db.connection.Query<DetailTransaksiModel>(sql, new
                {
                    id_menu = id
                }).ToList();

                foreach (var all in data)
                {
                    menu = mrepo.GetById(all.id_menu);
                    all.topping = menu.topping;

                    size = srepo.GetById(all.id_size);
                    all.size = size.size;

                }

                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public DetailTransaksiModel GetById(int id)
        {
            try
            {
                db.Open();
                var data = db.connection.Get<DetailTransaksiModel>(id);

                menu = mrepo.GetById(data.id_menu);
                data.topping = menu.topping;

                size = srepo.GetById(data.id_size);
                data.size = size.size;

                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
           
        }

        public bool Insert(DetailTransaksiModel detail)
        {
            try
            {
                db.Open();
                var data = db.connection.Insert<DetailTransaksiModel>(detail);

                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool Update(DetailTransaksiModel detail)
        {
            try
            {
                db.Open();
                var data = db.connection.Update<DetailTransaksiModel>(detail);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool Delete(DetailTransaksiModel detail)
        {
            try
            {
                db.Open();
                var data = db.connection.Delete<DetailTransaksiModel>(detail);
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
