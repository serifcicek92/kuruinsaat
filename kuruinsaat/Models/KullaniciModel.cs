using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace kuruinsaat.Models
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Adı")]
        [StringLength(50, ErrorMessage = "Adı 50 Karakteri Geçemez")]
        [Required]
        public string Adi { get; set; }

        [DisplayName("Soyadı")]
        [StringLength(50, ErrorMessage = "Soyadı 50 Karakteri Geçemez")]
        [Required]
        public string Soyadi { get; set; }

        public string ProfilResmi { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [StringLength(150, ErrorMessage = "Kullanıcı Adı 150 Karakteri Geçemez")]
        [Required]
        public string KullaniciAdi { get; set; }

        [DisplayName("Parola")]
        [Required]
        public string Parola { get; set; }

        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Parola", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ReParola { get; set; }

        [DisplayName("Mail Adres")]
        public string MailAdres { get; set; }
        public bool Cinsiyet { get; set; }
        public string Telefon { get; set; }

        [DisplayName("Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }
        public int? RolId { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }

        [DisplayName("Son Değişiklik Yapan")]
        public DateTime? SonDegisiklikYapan { get; set; }
        public bool Gecerlimi { get; set; }

        

    }
}