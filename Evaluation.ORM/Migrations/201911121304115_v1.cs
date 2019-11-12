namespace Evaluation.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VéhiculeIntervenant", "Véhicule_VéhiculeID", "dbo.Véhicule");
            DropForeignKey("dbo.VéhiculeIntervenant", "Intervenant_Matricule", "dbo.Intervenants");
            DropIndex("dbo.VéhiculeIntervenant", new[] { "Véhicule_VéhiculeID" });
            DropIndex("dbo.VéhiculeIntervenant", new[] { "Intervenant_Matricule" });
            CreateTable(
                "dbo.Matériel",
                c => new
                    {
                        MatérielID = c.Int(nullable: false, identity: true),
                        Désignation = c.String(),
                        Description = c.String(),
                        DateAchat = c.DateTime(nullable: false),
                        Dispo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MatérielID);
            
            DropTable("dbo.VéhiculeIntervenant");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VéhiculeIntervenant",
                c => new
                    {
                        Véhicule_VéhiculeID = c.Int(nullable: false),
                        Intervenant_Matricule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Véhicule_VéhiculeID, t.Intervenant_Matricule });
            
            DropTable("dbo.Matériel");
            CreateIndex("dbo.VéhiculeIntervenant", "Intervenant_Matricule");
            CreateIndex("dbo.VéhiculeIntervenant", "Véhicule_VéhiculeID");
            AddForeignKey("dbo.VéhiculeIntervenant", "Intervenant_Matricule", "dbo.Intervenants", "Matricule", cascadeDelete: true);
            AddForeignKey("dbo.VéhiculeIntervenant", "Véhicule_VéhiculeID", "dbo.Véhicule", "VéhiculeID", cascadeDelete: true);
        }
    }
}
