namespace Locations.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLatAndLngDoublesForChurchPosition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Churches", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.Churches", "Lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Churches", "Lng");
            DropColumn("dbo.Churches", "Lat");
        }
    }
}
