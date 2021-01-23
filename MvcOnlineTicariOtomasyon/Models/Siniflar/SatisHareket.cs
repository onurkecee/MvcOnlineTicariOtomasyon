using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SATISID { get; set; }
        //ÜRÜN
        //CARİ
        //PERSONEL
        public DateTime TARIH { get; set; }
        public int ADET { get; set; }
        public decimal FIYAT { get; set; }
        public decimal TOPLAMTUTAR { get; set; }


        public int URUNID { get; set; }
        public int CARIID { get; set; }
        public int PERSONELID  { get; set; }

        public virtual Urunler URUNLER { get; set; }
        public virtual Cariler CARILER { get; set; }
        public virtual Personel PERSONEL { get; set; }
    }
}