using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int ADMINID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string KULLANICIADI { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string SIFRE { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string YETKI { get; set; }
    }
}