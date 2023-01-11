using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace kuruinsaat.Models
{
    [Table("Roller")]
    public class Rol
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,StringLength(50, ErrorMessage ="En Fazla 50 karakterde olmalı")]
        public string RolAdi { get; set; }
        public bool Gecerlimi { get; set; }
        public List<Kullanici> Kullanici { get; set; }
    }
}