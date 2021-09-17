using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tarnetWeb.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        [DisplayName("Slider Başık"), StringLength(30, ErrorMessage ="Maksimum 30 karakter!")]
        public string Başlik { get; set; }
        [DisplayName("Slider Açıklama"), StringLength(150, ErrorMessage = "Maksimum 30 karakter!")]
        public string Aciklama { get; set; }
        [DisplayName("Slider Başık"), StringLength(250, ErrorMessage = "Maksimum 250 karakter!")]
        public string ResimURL { get; set; }

        

    }
}