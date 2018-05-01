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
        public DetailTransaksiRepo()
        {
            db = new Database();
        }

        public List<DetailTransaksiModel> GetAll()
        {
            try
            {
                db.Open();
                var data = db.connection.GetAll<DetailTransaksiModel>().ToList();
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
                DetailTransaksiModel detail = new DetailTransaksiModel();
                var data = db.connection.Query<DetailTransaksiModel>(sql,
                    new
                    {
                        detail.id_detail_transaksi,
                        detail.jumlah,
                        detail.harga_sekarang,
                        detail.total_harga,
                        detail.id_transaksi,
                        detail.id_menu
                    }).ToList();
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
                var sql = "SELECT * FROM t_detail_transaksi WHERE xid_menu = " + id;
                DetailTransaksiModel detail = new DetailTransaksiModel();
                var data = db.connection.Query<DetailTransaksiModel>(sql,
                    new
                    {
                        detail.id_detail_transaksi,
                        detail.jumlah,
                        detail.harga_sekarang,
                        detail.total_harga,
                        detail.id_transaksi,
                        detail.id_menu
                    }).ToList();
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
