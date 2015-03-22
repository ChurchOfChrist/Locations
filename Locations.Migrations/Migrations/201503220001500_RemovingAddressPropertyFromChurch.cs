namespace Locations.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingAddressPropertyFromChurch : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Churches", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Churches", "Address", c => c.String());
        }
    }
}
