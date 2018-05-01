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
            try
            {
                db.Open();
                var data = db.connection.GetAll<TransaksiModel>().ToList();
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public List<TransaksiModel> GetByIdPembeli(int id)
        {
            try
            {
                db.Open();
                var sql = "SELECT * FROM t_transaksi Where xid_pembeli = " + id;
                TransaksiModel trs = new TransaksiModel();
                var data = db.connection.Query<TransaksiModel>(sql,
                    new
                    {
                        trs.id_transaksi,
                        trs.tanggal,
                        trs.jumlah_beli,
                        trs.total_harga,
                        trs.id_toko
                    }).ToList();
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public List<TransaksiModel> GetByTanggal(string tanggal)
        {
            try
            {
                db.Open();
                var sql = "SELECT * FROM t_transaksi Where tanggal = '" + tanggal + "'";
                TransaksiModel trs = new TransaksiModel();
                var data = db.connection.Query<TransaksiModel>(sql).ToList();
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
           
        }

        public TransaksiModel GetById(int id)
        {
            try
            {
                db.Open();
                var data = db.connection.Get<TransaksiModel>(id);
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public int? GetLastId()
        {
            try
            {
                db.Open();
                string sql = "SELECT * FROM t_transaksi ORDER BY id_transaksi DESC LIMIT 1";
                var data = db.connection.QuerySingleOrDefault<TransaksiModel>(sql);
                db.Close();
                return data.id_transaksi;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public bool Insert(TransaksiModel transaksi)
        {
            try
            {
                db.Open();
                var data = db.connection.Insert<TransaksiModel>(transaksi);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool InsertAll(TransaksiSemuaModel value)
        {
            try
            {
                db.Open();
                value.parent.tanggal = DateTime.Now;
                value.parent.status = "waiting";
                var dataTransaksi = db.connection.Insert<TransaksiModel>(value.parent);
                int? lastid = GetLastId();
                foreach(var list in value.child)
                {
                    list.id_transaksi = (int) lastid;
                    var dataDetail = db.connection.Insert<DetailTransaksiModel>(list);
                }
                db.Close();

                return true;
            }catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(TransaksiModel transaksi)
        {
            try
            {
                db.Open();
                var data = db.connection.Update<TransaksiModel>(transaksi);
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool Delete(TransaksiModel transaksi)
        {
            try
            {
                db.Open();
                var data = db.connection.Delete<TransaksiModel>(transaksi);
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
