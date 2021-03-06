using System.Data.Entity.Migrations;

namespace Locations.Migrations.Migrations
{
    public partial class RemovingLocationGeographySpatial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Churches", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Churches", "Location", c => c.Geography());
        }
    }
}
