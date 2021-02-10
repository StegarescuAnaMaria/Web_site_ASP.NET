namespace Starset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "ImgLink", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "ImgLink");
        }
    }
}
