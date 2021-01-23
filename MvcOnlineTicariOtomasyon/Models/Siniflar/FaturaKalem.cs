using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FATURAKALEMID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(200)]
        public string ACIKLAMA { get; set; }
        public int MIKTAR { get; set; }
        public decimal BIRIMFIYAT { get; set; }
        public decimal TUTAR { get; set; }
        public int FATURAID { get; set; }
        public virtual Faturalar FATURALAR { get; set; }
    }
}