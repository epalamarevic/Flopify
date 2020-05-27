namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Album", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Band", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Band", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Track", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Track", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Track", "IsActive");
            DropColumn("dbo.Track", "UserId");
            DropColumn("dbo.Band", "IsActive");
            DropColumn("dbo.Band", "UserId");
            DropColumn("dbo.Album", "IsActive");
            DropColumn("dbo.Album", "UserId");
        }
    }
}
