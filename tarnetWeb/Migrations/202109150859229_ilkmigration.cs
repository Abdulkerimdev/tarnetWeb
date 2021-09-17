namespace tarnetWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilkmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Eposta = c.String(nullable: false, maxLength: 50),
                        Sifre = c.String(nullable: false, maxLength: 50),
                        Yetki = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        İcerik = c.String(),
                        ResimUrl = c.String(),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Kategori", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Hakkimizda",
                c => new
                    {
                        HakkimizdaId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HakkimizdaId);
            
            CreateTable(
                "dbo.Icerik",
                c => new
                    {
                        IcerikId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 200),
                        CikisYil = c.Int(nullable: false),
                        Dil = c.String(),
                        Aciklama = c.String(nullable: false, maxLength: 200),
                        Logo = c.String(),
                        IzlemeLink = c.String(nullable: false),
                        YorumLink = c.String(),
                    })
                .PrimaryKey(t => t.IcerikId);
            
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        IletisimId = c.Int(nullable: false, identity: true),
                        Adres = c.String(maxLength: 50),
                        Twitter = c.String(maxLength: 50),
                        Instagram = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IletisimId);
            
            CreateTable(
                "dbo.Kimlik",
                c => new
                    {
                        KimlikId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Keywords = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 200),
                        Logo = c.String(),
                        Link = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.KimlikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blog", "KategoriId", "dbo.Kategori");
            DropIndex("dbo.Blog", new[] { "KategoriId" });
            DropTable("dbo.Kimlik");
            DropTable("dbo.Iletisim");
            DropTable("dbo.Icerik");
            DropTable("dbo.Hakkimizda");
            DropTable("dbo.Kategori");
            DropTable("dbo.Blog");
            DropTable("dbo.Admin");
        }
    }
}
