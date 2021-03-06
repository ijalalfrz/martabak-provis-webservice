﻿using System;
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
    public class MenuRepo : InterRepo<MenuModel>
    {
        Database db;
        SizeModel size;
        SizeRepo srepo;

        public MenuRepo()
        {
            db = new Database();
            size = new SizeModel();
            srepo = new SizeRepo();
        }

        public MenuModel GetById(int id)
        {
            try
            {
                db.Open();
                var data = db.connection.Get<MenuModel>(id);
                var listSize = srepo.GetByIdMenu(id);
                foreach(var all in listSize)
                {
                    if(all.size == "Medium")
                    {
                        data.harga_medium = all.harga;
                    }
                    else
                    {
                        data.harga_large = all.harga;
                    }
                }
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public MenuModel GetByTopping(string topping)
        {
            try
            {
                db.Open();
                var selectSql = "SELECT * FROM t_menu WHERE topping = '"+topping+"'";

                var data = db.connection.QuerySingleOrDefault<MenuModel>(selectSql);

                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public List<MenuModel> GetAll()
        {
            try
            {
                db.Open();
                var data = db.connection.GetAll<MenuModel>().ToList();

                db.Close();
                return data;

            }
            catch (Exception e)
            {
                return null;
            }

        }

        public List<object> GetAllWithPrice()
        {
            try
            {

                db.Open();
                var selectSql = "SELECT t_menu.*, t_size.harga FROM t_menu INNER JOIN t_size ON t_menu.id_menu = t_size.id_menu WHERE t_size.size = 'Medium' ORDER BY t_menu.topping";

                var data = db.connection.Query<object>(selectSql).ToList();



                db.Close();
                return data;

            }
            catch (Exception e)
            {
                return null;
            }

        }

        public List<object> GetBestSellerMenu(int? limit)
        {
            try
            {
                string lim = "";
                if (limit != null)
                {
                    lim = " LIMIT " + limit;
                }
                else
                {
                    lim = " LIMIT 1";
                }

                db.Open();
                string sql = "SELECT * from t_detail_transaksi GROUP BY id_menu having count(*) > 0 order by count(*) desc";
                sql += lim;
                var trans = db.connection.Query<DetailTransaksiModel>(sql).ToList();



                var data = new List<object>();

                foreach (var all in trans)
                {
                    var selectSql = "SELECT t_menu.*, t_size.harga FROM t_menu INNER JOIN t_size ON t_size.id_menu = t_menu.id_menu WHERE t_menu.id_menu = " + all.id_menu + " AND t_size.size = 'Medium' ORDER BY t_menu.topping;";
                    var val = db.connection.QueryFirstOrDefault<object>(selectSql);
                    data.Add(val);
                }
                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<MenuModel> GetAllByTopping(string sort)
        {
            try
            {
                db.Open();
                var data = db.connection.GetAll<MenuModel>().ToList();

                foreach(var a in data)
                {
                    var listSize = srepo.GetByIdMenu(a.id_menu);
                    foreach (var all in listSize)
                    {
                        if (all.size == "Medium")
                        {
                            a.harga_medium = all.harga;
                        }
                        else
                        {
                            a.harga_large = all.harga;
                        }
                    }
                }

                

                List<MenuModel> SortedList;
                if (sort == "asc")
                {
                    SortedList = data.OrderBy(o => o.topping).ToList();
                }
                else
                {
                    SortedList = data.OrderByDescending(o => o.topping).ToList();
                }

                db.Close();
                return SortedList;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public List<object> GetByCategory(string kategori)
        {
            try
            {
                db.Open();
                var selectSql = "SELECT t_menu.*, t_size.harga FROM t_menu INNER JOIN t_size ON t_size.id_menu = t_menu.id_menu WHERE kategori_menu = '" + kategori + "' AND t_size.size = 'Medium' ORDER BY t_menu.topping;";

                var data = db.connection.Query<object>(selectSql, new
                {
                    kategori_menu = kategori
                }).ToList();



                db.Close();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public List<object> GetPriceById(int id)
        {
            try
            {
                db.Open();
                var selectSql = "SELECT t_menu.*,t_size.id_size, t_size.size, t_size.harga FROM t_menu INNER JOIN t_size ON t_size.id_menu = t_menu.id_menu WHERE t_menu.id_menu=" + id;

                var data = db.connection.Query<object>(selectSql, new
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

        public int? GetLastId()
        {
            try
            {
                db.Open();
                string sql = "SELECT * FROM t_menu ORDER BY id_menu DESC LIMIT 1";
                var data = db.connection.QuerySingleOrDefault<MenuModel>(sql);
                db.Close();
                return data.id_menu;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public bool Insert(MenuModel menu)
        {
            try
            {
                
                db.Open();
                var data = db.connection.Insert<MenuModel>(menu);
                int? lastid = GetLastId();

                size.id_menu = (int)lastid;
                size.harga = menu.harga_medium;
                size.size = "Medium";

                var dataSizeMedium = db.connection.Insert<SizeModel>(size);


                size.id_menu = (int)lastid;
                size.harga = menu.harga_large;
                size.size = "Large";

                var dataSizeLarge = db.connection.Insert<SizeModel>(size);

                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Update(MenuModel menu)
        {
            try
            {
                db.Open();
                var data = db.connection.Update<MenuModel>(menu);

                var listSize = srepo.GetByIdMenu(menu.id_menu);

                int id;

                foreach(var all in listSize)
                {
                    id = all.id_size;
                    if(all.size == "Medium")
                    {
                        all.harga = menu.harga_medium;
                    }
                    else
                    {
                        all.harga = menu.harga_large;
                    }

                    srepo.Update(all);
                    
                }

                db.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Delete(MenuModel menu)
        {
            try
            {
                db.Open();
                var listSize = srepo.GetByIdMenu(menu.id_menu);

                foreach (var all in listSize)
                {
                    srepo.Delete(all);
                }

                var data = db.connection.Delete<MenuModel>(menu);


                

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
