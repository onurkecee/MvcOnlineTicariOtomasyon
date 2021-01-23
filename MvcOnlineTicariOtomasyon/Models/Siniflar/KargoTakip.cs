using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KARGOTAKIPID { get; set; }

        [Column(TypeName ="VarChar")]
        [StringLength(25)]
        public string TAKIPNO { get; set; }

        [Column(TypeName ="VarChar")]
        [StringLength(100)]
        public string ACIKLAMA { get; set; }

        public DateTime TARIH { get; set; }
    }
}