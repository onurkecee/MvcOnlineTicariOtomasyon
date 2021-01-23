using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CARIID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz..")]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez.")]
        public string CARIAD { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez.")]
        public string CARISOYAD { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string CARISEHIR { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(90)]
        public string CARIMAIL { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string CARISIFRE { get; set; }

        public bool DURUM { get; set; }
        public ICollection<SatisHareket> SATISHAREKETS { get; set; }
    }
}