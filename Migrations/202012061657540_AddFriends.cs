namespace Starset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFriends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id1 = c.Int(nullable: false),
                        Id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Friends");
        }
    }
}
