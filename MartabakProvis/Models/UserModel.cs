using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartabakProvis.Models
{
    [Table("t_user")]
    public class UserModel
    {
        [Key]
        public int id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nama { get; set; }
        public string role { get; set; }
        public string id_toko { get; set; }
    }
}
