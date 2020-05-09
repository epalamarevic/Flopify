namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTrackDislikes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackDislike",
                c => new
                    {
                        TrackDislikeId = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrackDislikeId)
                .ForeignKey("dbo.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackDislike", "TrackId", "dbo.Track");
            DropIndex("dbo.TrackDislike", new[] { "TrackId" });
            DropTable("dbo.TrackDislike");
        }
    }
}
