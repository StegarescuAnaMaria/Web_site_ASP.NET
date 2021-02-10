namespace Starset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVideo1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Videos", "ImgLink", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "ImgLink", c => c.String(maxLength: 50));
        }
    }
}
