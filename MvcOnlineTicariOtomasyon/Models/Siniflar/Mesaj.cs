using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Mesaj
    {
        [Key]
        public int MESAJID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string GONDERICI { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string ALICI { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string KONU { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string ICERIK { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime TARIH { get; set; }
    }
}