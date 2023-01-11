using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace kuruinsaat.Models
{
    [Table("ElementTypes")]
    public class ElementType
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int Aktif { get; set; }
    }
}