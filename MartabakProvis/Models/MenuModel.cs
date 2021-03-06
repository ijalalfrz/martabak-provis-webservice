﻿using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartabakProvis.Repositories;
using MartabakProvis.Models;


namespace MartabakProvis.Models
{
    [Table("t_menu")]
    public class MenuModel
    {
 
        [Key]
        public int id_menu { get; set; }
        public string topping { get; set; }
        public string kategori_menu { get; set; }
        public string gambar { get; set; }
        public string deskripsi { get; set; }
        [Computed]
        public decimal harga_medium { get; set; }
        [Computed]
        public decimal harga_large { get; set; }


    }

    public class MenuViewModel
    {

        [Key]
        public int id_menu { get; set; }
        public string topping { get; set; }
        public string kategori_menu { get; set; }
        public IFormFile gambar { get; set; }
        public string deskripsi { get; set; }
        [Computed]
        public decimal harga_medium { get; set; }
        [Computed]
        public decimal harga_large { get; set; }



    }
}
