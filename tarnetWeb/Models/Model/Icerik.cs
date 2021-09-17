using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tarnetWeb.Models.Model
{
    [Table("Icerik")]
    public class Icerik
    {
        [Key]
        public int IcerikId { get; set; }

        [DisplayName("Film Başlık")]
        [Required, StringLength(200, ErrorMessage = "maks 200 karakter olabilir")]
        public string Baslik { get; set; }

        [DisplayName("Vizyon Tarihi")]
        public int CikisYil { get; set; }

        [DisplayName("Gösterim dili")]
        public string Dil { get; set; }

        [DisplayName("Film Açıklama")]
        [Required, StringLength(200, ErrorMessage = "maks 200 karakter olabilir")]
        public string Aciklama { get; set; }

        [DisplayName("Film Afiş ")]
        public string Logo { get; set; }

        [DisplayName("Bağlantı Linkleri")]
        [Required]
        public string IzlemeLink { get; set; }

        [DisplayName("İnceleme Linki ")]
        public string YorumLink { get; set; }

    }
}