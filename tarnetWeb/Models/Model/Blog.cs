using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tarnetWeb.Models.Model
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public string ResimUrl { get; set; }
        public int KategoriId { get; set; }

        public Kategori Kategori { get; set; }

    }
}