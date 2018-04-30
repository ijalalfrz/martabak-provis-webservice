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

        public MenuRepo()
        {
            db = new Database();
        }

        public MenuModel GetById(int id)
        {
            db.Open();
            var data = db.connection.Get<MenuModel>(id);
            db.Close();
            return data;
        }


        public List<MenuModel> GetAll()
        {
            db.Open();
            var data = db.connection.GetAll<MenuModel>().ToList();
            
            db.Close();
            return data;
        }

        public List<object> GetAllWithPrice()
        {
            db.Open();
            var selectSql = "SELECT t_menu.*, t_size.harga FROM t_menu INNER JOIN t_size ON t_menu.id_menu = t_size.id_menu WHERE t_size.size = 'Medium'";
            var data = db.connection.Query<object>(selectSql).ToList();

            db.Close();
            return data;
        }

        public List<MenuModel> GetAllByTopping(string sort)
        {
            db.Open();
            var data = db.connection.GetAll<MenuModel>().ToList();
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

        public List<object> GetByCategory(string kategori)
        {
            db.Open();
            var selectSql = "SELECT t_menu.*, t_size.harga FROM t_menu INNER JOIN t_size ON t_size.id_menu = t_menu.id_menu WHERE kategori_menu = '" + kategori + "' AND t_size.size = 'Medium'";

            var data = db.connection.Query<object>(selectSql, new
            {
                kategori_menu = kategori
            }).ToList();
            db.Close();
            return data;
        }

        public List<object> GetPriceById(int id)
        {
            db.Open();
            var selectSql = "SELECT t_menu.*, t_size.size, t_size.harga FROM t_menu INNER JOIN t_size ON t_size.id_menu = t_menu.id_menu WHERE t_menu.id_menu=" + id ;

            var data = db.connection.Query<object>(selectSql, new
            {
                id_menu = id
            }).ToList();
            db.Close();
            return data;
        }

        public bool Insert(MenuModel menu)
        {
            db.Open();
            var data = db.connection.Insert<MenuModel>(menu);
            db.Close();
            return true;
        }

        public bool Update(MenuModel menu)
        {
            db.Open();
            var data = db.connection.Update<MenuModel>(menu);
            db.Close();
            return true;
        }

        public bool Delete(MenuModel menu)
        {
            db.Open();
            var data = db.connection.Delete<MenuModel>(menu);
            db.Close();
            return true;
        }

       
    }
}
