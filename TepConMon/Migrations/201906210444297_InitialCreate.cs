namespace TepConMon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        ZakazchikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zakazchiks", t => t.ZakazchikId, cascadeDelete: true)
                .Index(t => t.ZakazchikId);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zakazchiks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderMaterials",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Material_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Material_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.Material_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Material_Id);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        Work_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Work_Id, t.Order_Id })
                .ForeignKey("dbo.Works", t => t.Work_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Work_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.WorkerWorks",
                c => new
                    {
                        Worker_Id = c.Int(nullable: false),
                        Work_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Worker_Id, t.Work_Id })
                .ForeignKey("dbo.Workers", t => t.Worker_Id, cascadeDelete: true)
                .ForeignKey("dbo.Works", t => t.Work_Id, cascadeDelete: true)
                .Index(t => t.Worker_Id)
                .Index(t => t.Work_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ZakazchikId", "dbo.Zakazchiks");
            DropForeignKey("dbo.WorkerWorks", "Work_Id", "dbo.Works");
            DropForeignKey("dbo.WorkerWorks", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.WorkOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.WorkOrders", "Work_Id", "dbo.Works");
            DropForeignKey("dbo.OrderMaterials", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.OrderMaterials", "Order_Id", "dbo.Orders");
            DropIndex("dbo.WorkerWorks", new[] { "Work_Id" });
            DropIndex("dbo.WorkerWorks", new[] { "Worker_Id" });
            DropIndex("dbo.WorkOrders", new[] { "Order_Id" });
            DropIndex("dbo.WorkOrders", new[] { "Work_Id" });
            DropIndex("dbo.OrderMaterials", new[] { "Material_Id" });
            DropIndex("dbo.OrderMaterials", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "ZakazchikId" });
            DropTable("dbo.WorkerWorks");
            DropTable("dbo.WorkOrders");
            DropTable("dbo.OrderMaterials");
            DropTable("dbo.Zakazchiks");
            DropTable("dbo.Workers");
            DropTable("dbo.Works");
            DropTable("dbo.Orders");
            DropTable("dbo.Materials");
        }
    }
}
