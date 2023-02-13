using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace kuruinsaat.Models
{
    [Table("Projeler")]
    public class Proje
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Adı")]
        public string Adi { get; set; }
        [DisplayName("Blok Adedi")]
        public int? BlokAdedi { get; set; }
        [DisplayName("Toplam Konut Sayısı")]
        public int? ToplamKonutSayisi { get; set; }
        [DisplayName("Arsa Alanı")]
        public int? ArsaAlani { get; set; }
        [DisplayName("Kullanılabilir Alan")]
        public int? KullanilabilirAlan { get; set; }
        [DisplayName("Teslim Tarihi")]
        public DateTime? TeslimTarihi { get; set; }
        [DisplayName("Adresi")]
        public string Adres { get; set; }
        [DisplayName("Sıra")]
        public int? Sira { get; set; }
        [DisplayName("Proje Tamamlandımı?")]
        public bool Tamamlandimi { get; set; }
        public int? EkleyenId { get; set; }
        //[ForeignKey("EkleyenId")]
        //public virtual Kullanici Ekleyen { get; set; }
        public DateTime? EklemeZamani { get; set; }
        public int? GuncelleyenId { get; set; }
        //[ForeignKey("GuncelleyenId")]
        //public virtual Kullanici Guncelleyen { get; set; }
        public DateTime? Guncellemezamani { get; set; }
        public int? Aktif { get; set; }


    }
}