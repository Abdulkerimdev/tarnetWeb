namespace tarnetWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guncelleme21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slider", "Aciklama", c => c.String(maxLength: 150));
            AlterColumn("dbo.Slider", "ResimURL", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slider", "ResimURL", c => c.String(maxLength: 30));
            AlterColumn("dbo.Slider", "Aciklama", c => c.String(maxLength: 30));
        }
    }
}
