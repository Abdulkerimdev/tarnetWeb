using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tarnetWeb.Models.Model
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }
        [StringLength(50, ErrorMessage = "50 Karakter olmalı")]
        public string Adres { get; set; }
        [StringLength(50, ErrorMessage = "50 Karakter olmalı")]
        public string Twitter { get; set; }
        [StringLength(50, ErrorMessage = "50 Karakter olmalı")]
        public string Instagram { get; set; }

    }
}