using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int KARGODETAYID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string ACIKLAMA { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TAKIPKODU { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PERSONEL { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string ALICI { get; set; }

        public DateTime TARIH { get; set; }
    }
}