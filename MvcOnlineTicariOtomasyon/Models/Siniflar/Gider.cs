using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GIDERID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string ACIKLAMA { get; set; }
        public DateTime TARIH { get; set; }
        public decimal TUTAR { get; set; }
    }
}