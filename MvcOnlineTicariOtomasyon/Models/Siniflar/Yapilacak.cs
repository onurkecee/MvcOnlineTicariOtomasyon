using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Yapilacak
    {
        [Key]
        public int YAPILACAKID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string BASLIK { get; set; }

        [Column(TypeName = "bit")]
        public bool DURUM { get; set; }
        
    }
}