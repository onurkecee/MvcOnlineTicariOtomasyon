using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urunler
    {
        [Key]
        public int URUNID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Ürün Adını Giriniz")]
        public string URUNAD { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Ürün Markası Giriniz")]
        public string MARKA { get; set; }

        [Required(ErrorMessage = "Stok Sayısı Mutlaka Girilmeli")]
        public short STOK { get; set; }

        [Required(ErrorMessage = "Alış Fiyatı Mutlaka Girilmeli")]
        [RegularExpression("abcdefghıijklmnoöprsştuüvyzxwqABCDEFGHIİJLKMNOÖPRSŞTUÜVYZQWX!'^+%&/()=?_-*>£#$½|<>", ErrorMessage = "Sadece Sayı Girişi Yapılabilir")]
        public decimal ALISFIYAT { get; set; }

        [Required(ErrorMessage = "Satış Fiyatı Mutlaka Girilmeli")]
        public decimal SATISFIYAT { get; set; }

        public bool DURUM { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string URUNGORSEL { get; set; }

        public int KATEGORIID { get; set; }

        public virtual Kategori KATEGORI { get; set; }

        public ICollection<SatisHareket> SATISHAREKETS { get; set; }

    }
}