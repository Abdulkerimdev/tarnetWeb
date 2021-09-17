namespace tarnetWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guncelleme2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Başlik = c.String(maxLength: 30),
                        Aciklama = c.String(maxLength: 30),
                        ResimURL = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.SliderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Slider");
        }
    }
}
