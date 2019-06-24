namespace TepConMon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnot : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Materials", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.Works", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Workers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Zakazchiks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Zakazchiks", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Zakazchiks", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zakazchiks", "Address", c => c.String());
            AlterColumn("dbo.Zakazchiks", "Email", c => c.String());
            AlterColumn("dbo.Zakazchiks", "Name", c => c.String());
            AlterColumn("dbo.Workers", "Name", c => c.String());
            AlterColumn("dbo.Works", "Name", c => c.String());
            AlterColumn("dbo.Orders", "Number", c => c.String());
            AlterColumn("dbo.Materials", "Name", c => c.String());
        }
    }
}
