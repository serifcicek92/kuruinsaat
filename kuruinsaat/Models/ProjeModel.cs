using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace kuruinsaat.Models
{
    [Table("Projeler")]
    public class Proje
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public int BlokAdedi { get; set; }

        public int ToplamKonutSayisi { get; set; }
        public int ArsaAlani { get; set; }
        public int KullanilabilirAlan { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public string Adres { get; set; }
        public int? EkleyenId { get; set; }
        //[ForeignKey("EkleyenId")]
        //public virtual Kullanici Ekleyen { get; set; }
        public DateTime EklemeZamani { get; set; }
        public int? GuncelleyenId { get; set; }
        //[ForeignKey("GuncelleyenId")]
        //public virtual Kullanici Guncelleyen { get; set; }
        public DateTime Guncellemezamani { get; set; }
        public int Aktif { get; set; }


    }
}