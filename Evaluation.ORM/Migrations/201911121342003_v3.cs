namespace Evaluation.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Intervenants", "Administrator_ID", c => c.Int());
            AddColumn("dbo.Interventions", "DateDebut", c => c.DateTime(nullable: false));
            AddColumn("dbo.Interventions", "DateFin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matériel", "Administrator_ID", c => c.Int());
            AddColumn("dbo.Véhicule", "Administrator_ID", c => c.Int());
            CreateIndex("dbo.Intervenants", "Administrator_ID");
            CreateIndex("dbo.Matériel", "Administrator_ID");
            CreateIndex("dbo.Véhicule", "Administrator_ID");
            AddForeignKey("dbo.Intervenants", "Administrator_ID", "dbo.Administrators", "ID");
            AddForeignKey("dbo.Matériel", "Administrator_ID", "dbo.Administrators", "ID");
            AddForeignKey("dbo.Véhicule", "Administrator_ID", "dbo.Administrators", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Véhicule", "Administrator_ID", "dbo.Administrators");
            DropForeignKey("dbo.Matériel", "Administrator_ID", "dbo.Administrators");
            DropForeignKey("dbo.Intervenants", "Administrator_ID", "dbo.Administrators");
            DropIndex("dbo.Véhicule", new[] { "Administrator_ID" });
            DropIndex("dbo.Matériel", new[] { "Administrator_ID" });
            DropIndex("dbo.Intervenants", new[] { "Administrator_ID" });
            DropColumn("dbo.Véhicule", "Administrator_ID");
            DropColumn("dbo.Matériel", "Administrator_ID");
            DropColumn("dbo.Interventions", "DateFin");
            DropColumn("dbo.Interventions", "DateDebut");
            DropColumn("dbo.Intervenants", "Administrator_ID");
            DropTable("dbo.Administrators");
        }
    }
}
