namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTrackDisikesToAlbum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Album", "NumberOfTracks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Album", "NumberOfTracks", c => c.Int(nullable: false));
        }
    }
}
