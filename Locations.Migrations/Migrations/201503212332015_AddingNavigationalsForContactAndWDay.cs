namespace Locations.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNavigationalsForContactAndWDay : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Church_Id", "dbo.Churches");
            DropForeignKey("dbo.WorshipDays", "Church_Id", "dbo.Churches");
            DropIndex("dbo.Contacts", new[] { "Church_Id" });
            DropIndex("dbo.WorshipDays", new[] { "Church_Id" });
            RenameColumn(table: "dbo.Contacts", name: "Church_Id", newName: "ChurchId");
            RenameColumn(table: "dbo.WorshipDays", name: "Church_Id", newName: "ChurchId");
            AlterColumn("dbo.Contacts", "ChurchId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorshipDays", "ChurchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "ChurchId");
            CreateIndex("dbo.WorshipDays", "ChurchId");
            AddForeignKey("dbo.Contacts", "ChurchId", "dbo.Churches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorshipDays", "ChurchId", "dbo.Churches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorshipDays", "ChurchId", "dbo.Churches");
            DropForeignKey("dbo.Contacts", "ChurchId", "dbo.Churches");
            DropIndex("dbo.WorshipDays", new[] { "ChurchId" });
            DropIndex("dbo.Contacts", new[] { "ChurchId" });
            AlterColumn("dbo.WorshipDays", "ChurchId", c => c.Int());
            AlterColumn("dbo.Contacts", "ChurchId", c => c.Int());
            RenameColumn(table: "dbo.WorshipDays", name: "ChurchId", newName: "Church_Id");
            RenameColumn(table: "dbo.Contacts", name: "ChurchId", newName: "Church_Id");
            CreateIndex("dbo.WorshipDays", "Church_Id");
            CreateIndex("dbo.Contacts", "Church_Id");
            AddForeignKey("dbo.WorshipDays", "Church_Id", "dbo.Churches", "Id");
            AddForeignKey("dbo.Contacts", "Church_Id", "dbo.Churches", "Id");
        }
    }
}
