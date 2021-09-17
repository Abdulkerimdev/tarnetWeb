using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tarnetWeb.Models.Model
{
    [Table("Kimlik")]
    public class Kimlik
    {
        [Key]
        public int KimlikId { get; set; }
        [DisplayName("Site Başlık")]
        [Required,StringLength(200, ErrorMessage = "maks 200 karakter olabilir")]
        public string Title { get; set; }
        [DisplayName("Anahtar Kelimeler")]
        [Required, StringLength(200, ErrorMessage = "maks 200 karakter olabilir")]
        public string Keywords { get; set; }
        [DisplayName("Sayfa Açıklama")]
        [Required, StringLength(200, ErrorMessage = "maks 200 karakter olabilir")]
        public string Description { get; set; }
        [DisplayName("Site Logo")]
        public string Logo { get; set; }
        [DisplayName("Bağlantı Linkleri")]
        [Required, StringLength(200, ErrorMessage = "maks 200 karakter olabilir")]
        public string Link { get; set; }
    }
}