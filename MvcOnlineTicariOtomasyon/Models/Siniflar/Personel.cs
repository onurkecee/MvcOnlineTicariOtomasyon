using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PERSONELID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PERSONELAD { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PERSONELSOYAD { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string PERSONELGORSEL { get; set; }
        public ICollection<SatisHareket> SATISHAREKETS { get; set; }
        public int DEPARTMANID { get; set; }
        public virtual Departman DEPARTMAN { get; set; }
    }
}