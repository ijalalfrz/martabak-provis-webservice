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
        TokoModel toko;
        TokoRepo trepo;
        public TransaksiRepo()
        {
            db = new Database();
            toko = new TokoModel();
            trepo = new TokoRepo();
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

        public List<object> GetAllWithDetail()
        {
            try
            {
                var sql = "SELECT t_transaksi.*, t_toko.nama_toko " +
                    "FROM t_transaksi LEFT JOIN t_toko " +
                    "ON t_toko.id_toko = t_transaksi.id_toko;";
                var transaksi = db.connection.Query<TransaksiModel>(sql).ToList();


                var detail = new List<object>();
                foreach (var all in transaksi)
                {
                    sql = "SELECT t_detail_transaksi.*, t_menu.topping, t_size.size " +
                        "FROM t_detail_transaksi " +
                        "INNER JOIN t_menu " +
                        "ON t_detail_transaksi.id_menu = t_menu.id_menu " +
                        "INNER JOIN t_size " +
                        "ON t_size.id_size = t_detail_transaksi.id_size " +
                        "WHERE t_detail_transaksi.id_transaksi = " + all.id_transaksi;
                    var det = db.connection.Query<DetailTransaksiModel>(sql).ToList();


                    detail.Add(new
                    {
                        transaksi = all,
                        detail = det
                    });
                }


                return detail;
            }
            catch (Exception e)
            {
                return null;
            }         
        }

        public List<object> GetAllWithDetailDate(int? limit)
        {
            try
            {
                string lim = "";
                if (limit != null)
                {
                    lim = " LIMIT " + limit;
                }

                var sql = "SELECT t_transaksi.*, t_toko.nama_toko " +
                    "FROM t_transaksi LEFT JOIN t_toko " +
                    "ON t_toko.id_toko = t_transaksi.id_toko ORDER BY t_transaksi.tanggal DESC ";
                sql += lim;
                var transaksi = db.connection.Query<TransaksiModel>(sql).ToList();


                var detail = new List<object>();
                foreach (var all in transaksi)
                {
                    sql = "SELECT t_detail_transaksi.*, t_menu.topping, t_size.size " +
                        "FROM t_detail_transaksi " +
                        "INNER JOIN t_menu " +
                        "ON t_detail_transaksi.id_menu = t_menu.id_menu " +
                        "INNER JOIN t_size " +
                        "ON t_size.id_size = t_detail_transaksi.id_size " +
                        "WHERE t_detail_transaksi.id_transaksi = " + all.id_transaksi;
                    var det = db.connection.Query<DetailTransaksiModel>(sql).ToList();


                    detail.Add(new
                    {
                        transaksi = all,
                        detail = det
                    });
                }


                return detail;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<object> GetByIdToko(int id)
        {
            try
            {
                var sql = "SELECT t_transaksi.*, t_toko.nama_toko " +
                    "FROM t_transaksi LEFT JOIN t_toko " +
                    "ON t_toko.id_toko = t_transaksi.id_toko " +
                    "WHERE t_transaksi.id_toko = " + id + " ORDER BY t_transaksi.tanggal DESC";
                var transaksi = db.connection.Query<TransaksiModel>(sql).ToList();


                var detail = new List<object>();
                foreach (var all in transaksi)
                {
                    sql = "SELECT t_detail_transaksi.*, t_menu.topping, t_size.size " +
                        "FROM t_detail_transaksi " +
                        "INNER JOIN t_menu " +
                        "ON t_detail_transaksi.id_menu = t_menu.id_menu " +
                        "INNER JOIN t_size " +
                        "ON t_size.id_size = t_detail_transaksi.id_size " +
                        "WHERE t_detail_transaksi.id_transaksi = " + all.id_transaksi;
                    var det = db.connection.Query<DetailTransaksiModel>(sql).ToList();


                    detail.Add(new
                    {
                        transaksi = all,
                        detail = det
                    });
                }


                return detail;
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
                //toko = trepo.GetById((int)data.id_toko);
                //data.nama_toko = toko.nama_toko;
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

        public bool UpdateStatus(int id)
        {
            try
            {
                TransaksiModel transaksi = new TransaksiModel();
                transaksi = GetById(id);
                transaksi.status = "done";
                if (Update(transaksi))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception e)
            {
                return false;
            }
        }

        public List<object> GetTransaksiByStatus(string status, int? limit)
        {
            try
            {
                string lim = "";
                if(limit != null)
                {
                    lim = " LIMIT " + limit;
                }

                var sql = "SELECT t_transaksi.*, t_toko.nama_toko " +
                    "FROM t_transaksi LEFT JOIN t_toko " +
                    "ON t_toko.id_toko = t_transaksi.id_toko " +
                    "WHERE t_transaksi.status = '" + status + "' ORDER BY t_transaksi.tanggal DESC";
                sql += lim;
                var transaksi = db.connection.Query<TransaksiModel>(sql).ToList();


                var detail = new List<object>();
                foreach (var all in transaksi)
                {
                    sql = "SELECT t_detail_transaksi.*, t_menu.topping, t_size.size " +
                        "FROM t_detail_transaksi " +
                        "INNER JOIN t_menu " +
                        "ON t_detail_transaksi.id_menu = t_menu.id_menu " +
                        "INNER JOIN t_size " +
                        "ON t_size.id_size = t_detail_transaksi.id_size " +
                        "WHERE t_detail_transaksi.id_transaksi = " + all.id_transaksi;
                    var det = db.connection.Query<DetailTransaksiModel>(sql).ToList();


                    detail.Add(new
                    {
                        transaksi = all,
                        detail = det
                    });
                }

                return detail;

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

        public bool InsertAll(TransaksiViewModel value)
        {
            try
            {
                db.Open();
                value.transaksi.tanggal = DateTime.Now;
                value.transaksi.status = "waiting";
                var dataTransaksi = db.connection.Insert<TransaksiModel>(value.transaksi);
                int? lastid = GetLastId();
                foreach(var list in value.detail)
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
