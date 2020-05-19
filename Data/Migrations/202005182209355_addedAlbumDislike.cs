namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAlbumDislike : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumDislike",
                c => new
                    {
                        AlbumDislikeId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumDislikeId)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            AddColumn("dbo.Track", "PlayTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumDislike", "AlbumId", "dbo.Album");
            DropIndex("dbo.AlbumDislike", new[] { "AlbumId" });
            DropColumn("dbo.Track", "PlayTime");
            DropTable("dbo.AlbumDislike");
        }
    }
}
