namespace Locations.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingTiemSpanToDateTimeonChurch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Church_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.Church_Id)
                .Index(t => t.Church_Id);
            
            CreateTable(
                "dbo.WorshipDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Church_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.Church_Id)
                .Index(t => t.Church_Id);
            
            AddColumn("dbo.Churches", "Comment", c => c.String());
            DropColumn("dbo.Churches", "Preacher");
            DropColumn("dbo.Churches", "WorshipDays");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Churches", "WorshipDays", c => c.String());
            AddColumn("dbo.Churches", "Preacher", c => c.String());
            DropForeignKey("dbo.WorshipDays", "Church_Id", "dbo.Churches");
            DropForeignKey("dbo.Contacts", "Church_Id", "dbo.Churches");
            DropIndex("dbo.WorshipDays", new[] { "Church_Id" });
            DropIndex("dbo.Contacts", new[] { "Church_Id" });
            DropColumn("dbo.Churches", "Comment");
            DropTable("dbo.WorshipDays");
            DropTable("dbo.Contacts");
        }
    }
}
