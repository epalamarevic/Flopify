namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAlbumsAndBands : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PlayTime = c.Time(nullable: false, precision: 7),
                        NumberOfTracks = c.Int(nullable: false),
                        DateReleased = c.DateTime(nullable: false),
                        BandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Band", t => t.BandId, cascadeDelete: true)
                .Index(t => t.BandId);
            
            CreateTable(
                "dbo.Band",
                c => new
                    {
                        BandId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        Members = c.String(),
                        NumberOfAlbums = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BandId);
            
            AddColumn("dbo.Track", "AlbumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Track", "AlbumId");
            AddForeignKey("dbo.Track", "AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
            DropColumn("dbo.Track", "Dislikes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Track", "Dislikes", c => c.Int(nullable: false));
            DropForeignKey("dbo.Track", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "BandId", "dbo.Band");
            DropIndex("dbo.Track", new[] { "AlbumId" });
            DropIndex("dbo.Album", new[] { "BandId" });
            DropColumn("dbo.Track", "AlbumId");
            DropTable("dbo.Band");
            DropTable("dbo.Album");
        }
    }
}
