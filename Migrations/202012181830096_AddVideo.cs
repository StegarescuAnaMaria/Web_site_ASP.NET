namespace Starset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false, maxLength: 100),
                        VideoId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Videos");
        }
    }
}
