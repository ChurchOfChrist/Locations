using System.Data.Entity.Migrations;

namespace Locations.Migrations.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Churches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Preacher = c.String(),
                        WorshipDays = c.String(),
                        Location = c.Geography(),
                        Address = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Churches");
        }
    }
}
