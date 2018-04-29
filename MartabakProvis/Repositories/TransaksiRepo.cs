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
    public class TransaksiRepo : InterRepo<TransaksiModel>
    {
        Database db;
        public TransaksiRepo()
        {
            db = new Database();
        }

        public List<TransaksiModel> GetAll()
        {
            db.Open();
            var data = db.connection.GetAll<TransaksiModel>().ToList();
            db.Close();
            return data;
        }

        public List<TransaksiModel> GetByIdPembeli(int id)
        {
            db.Open();
            var sql = "SELECT * FROM t_transaksi Where xid_pembeli = " + id;
            TransaksiModel trs = new TransaksiModel();
            var data = db.connection.Query<TransaksiModel>(sql, 
                new {
                    trs.id_transaksi,
                    trs.tanggal,
                    trs.jumlah_beli,
                    trs.total_harga,
                    trs.id_user
                }).ToList();
            db.Close();
            return data;
        }

        public List<TransaksiModel> GetByTanggal(string tanggal)
        {
            db.Open();
            var sql = "SELECT * FROM t_transaksi Where tanggal = '" + tanggal+"'";
            TransaksiModel trs = new TransaksiModel();
            var data = db.connection.Query<TransaksiModel>(sql,
                new
                {
                    trs.id_transaksi,
                    trs.tanggal,
                    trs.jumlah_beli,
                    trs.total_harga,
                    trs.id_user
                }).ToList();
            db.Close();
            return data;
        }

        public TransaksiModel GetById(int id)
        {
            db.Open();
            var data = db.connection.Get<TransaksiModel>(id);
            db.Close();
            return data;
        }

        public bool Insert(TransaksiModel transaksi)
        {
            db.Open();
            var data = db.connection.Insert<TransaksiModel>(transaksi);
            db.Close();
            return true;
        }

        public bool Update(TransaksiModel transaksi)
        {
            db.Open();
            var data = db.connection.Update<TransaksiModel>(transaksi);
            db.Close();
            return true;
        }

        public bool Delete(TransaksiModel transaksi)
        {
            db.Open();
            var data = db.connection.Delete<TransaksiModel>(transaksi);
            db.Close();
            return true;
        }
    }
}
