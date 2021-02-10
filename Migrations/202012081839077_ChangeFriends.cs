namespace Starset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFriends : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Friends", "Id1", c => c.String(nullable: false));
            AlterColumn("dbo.Friends", "Id2", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Friends", "Id2", c => c.Int(nullable: false));
            AlterColumn("dbo.Friends", "Id1", c => c.Int(nullable: false));
        }
    }
}
