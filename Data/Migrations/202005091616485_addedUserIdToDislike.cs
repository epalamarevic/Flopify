namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserIdToDislike : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackDislike", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrackDislike", "UserId");
        }
    }
}
