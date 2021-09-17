using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using tarnetWeb.Models.Model;

namespace tarnetWeb.Models.DataContext
{
    public class alloverMovieDB:DbContext
    {
        public alloverMovieDB():base("alloverDb")
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Icerik> Icerik  { get; set; }
        public DbSet<Kimlik> Kimliks { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Slider> Slider { get; set; }

    }
}