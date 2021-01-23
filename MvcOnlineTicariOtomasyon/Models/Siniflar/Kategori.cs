using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KATEGORIID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string KATEGORIAD { get; set; }
        public ICollection<Urunler> URUNS { get; set; }
    }
}