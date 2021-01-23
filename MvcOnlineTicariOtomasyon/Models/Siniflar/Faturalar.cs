using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FATURAID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FATURASERİNO { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string FATURASIRANO { get; set; }
        public DateTime TARIH { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string VERGIDAIRESI { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string SAAT { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TESLIMEDEN { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TESLIMALAN { get; set; }

        public decimal TOPLAM { get; set; }
        public ICollection<FaturaKalem> FATURAKALEMS { get; set; }
    }
}