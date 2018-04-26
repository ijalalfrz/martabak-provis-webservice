using System;
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


        public bool Delete(MenuModel menu)
        {
            db.Open();
            var data = db.connection.Delete<MenuModel>(menu);
            db.Close();
            return true;
        }

        public List<MenuModel> GetAll()
        {
            db.Open();
            var data = db.connection.GetAll<MenuModel>().ToList();
            
            db.Close();
            return data;
        }

        public List<MenuModel> GetAllHargaAscending()
        {
            db.Open();
            var data = db.connection.GetAll<MenuModel>().ToList();

            List<MenuModel> SortedList = data.OrderBy(o => o.harga).ToList();

            db.Close();
            return SortedList;
        }

        public List<MenuModel> GetAllHargaDescending()
        {
            db.Open();
            var data = db.connection.GetAll<MenuModel>().ToList();

            List<MenuModel> SortedList = data.OrderByDescending(o => o.harga).ToList();

            db.Close();
            return SortedList;
        }

        public List<MenuModel> GetAllNamaAscending()
        {
            db.Open();
            var data = db.connection.GetAll<MenuModel>().ToList();

            List<MenuModel> SortedList = data.OrderBy(o => o.topping).ToList();

            db.Close();
            return SortedList;
        }

        public List<MenuModel> GetAllNamaDescending()
        {
            db.Open();
            var data = db.connection.GetAll<MenuModel>().ToList();

            List<MenuModel> SortedList = data.OrderByDescending(o => o.topping).ToList();

            db.Close();
            return SortedList;
        }

        public List<MenuModel> GetByCategory(string kategori)
        {
            db.Open();
            var selectSql = "SELECT * FROM t_menu WHERE kategori_menu = @kategori";
            MenuModel menu = new MenuModel();
            var data = db.connection.Query<MenuModel>(selectSql, new
            {
                kategori_menu = kategori
            }).ToList();
            db.Close();
            return data;
        }

        public List<MenuModel> GetBySize(string size)
        {
            db.Open();
            var selectSql = "SELECT * FROM t_menu WHERE size_menu = @size ";
            MenuModel menu = new MenuModel();
            var data = db.connection.Query<MenuModel>(selectSql,new
            {
                size = size
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

        public MenuModel GetById(int id)
        {
            db.Open();
            var data = db.connection.Get<MenuModel>(id);
            db.Close();
            return data;
        }

       
    }
}
