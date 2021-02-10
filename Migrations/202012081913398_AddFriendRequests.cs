namespace Starset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFriendRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InitiatorId = c.String(nullable: false),
                        TargetId = c.String(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        Waiting = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FriendRequests");
        }
    }
}
