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
            db.Open();
            var data = db.connection.GetAll<DetailTransaksiModel>().ToList();
            db.Close();
            return data;
        }

        public List<DetailTransaksiModel> GetByIdTransaksi(int id)
        {
            db.Open();
            var sql = "SELECT * FROM t_detail_transaksi WHERE xid_transaksi = " + id;
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

        public List<DetailTransaksiModel> GetByIdMenu(int id)
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

        public DetailTransaksiModel GetById(int id)
        {
            db.Open();
            var data = db.connection.Get<DetailTransaksiModel>(id);
            db.Close();
            return data;
        }

        public bool Insert(DetailTransaksiModel detail)
        {
            db.Open();
            var data = db.connection.Insert<DetailTransaksiModel>(detail);
            db.Close();
            return true;
        }

        public bool Update(DetailTransaksiModel detail)
        {
            db.Open();
            var data = db.connection.Update<DetailTransaksiModel>(detail);
            db.Close();
            return true;
        }

        public bool Delete(DetailTransaksiModel detail)
        {
            db.Open();
            var data = db.connection.Delete<DetailTransaksiModel>(detail);
            db.Close();
            return true;
        }
    }
}
