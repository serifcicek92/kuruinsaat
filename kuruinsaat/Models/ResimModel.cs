using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace kuruinsaat.Models
{
    [Table("Resimler")]
    public class Resim
    {
        public int Id { get; set; }
        public string ResimYolu { get; set; }
        public string Title { get; set; }
        public string link { get; set; }
        public int ElementTypeId { get; set; }
        public ElementType ElementType { get; set; }
        public int EkleyenId { get; set; }
        //public Kullanici Ekleyen { get; set; }
        public DateTime EklemeZamani { get; set; }
        public int GuncelleyenId { get; set; }
        //public Kullanici Guncelleyen { get; set; }
        public DateTime Guncellemezamani { get; set; }
        public int Aktif { get; set; }
    }
}